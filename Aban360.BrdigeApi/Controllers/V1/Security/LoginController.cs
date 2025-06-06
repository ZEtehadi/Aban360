﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aban360.Common.Extensions;
using Aban360.UserPool.Domain.Features.Auth.Dto.Commands;
using Aban360.UserPool.Application.Features.Auth.Handlers.Queries.Contracts;
using Aban360.Common.Categories.ApiResponse;
using Aban360.UserPool.Application.Features.Auth.Services.Contracts;
using Aban360.UserPool.Application.Features.Auth.Handlers.Commands.Create.Contracts;
using Aban360.UserPool.Persistence.Contexts.UnitOfWork;
using Aban360.UserPool.Domain.Constants;
using Aban360.UserPool.Domain.Features.Auth.Entities;
using Aban360.UserPool.Domain.Features.Auth.Dto.Queries;

namespace Aban360.BrdigeApi.Controllers.V1.Security
{
    [Route("v1/login")]
    public class LoginController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserFindByUsernamePasswordHandler _userFindByPasswordHandler;
        private readonly ICaptchaGetSingleHandler _captchaGetSingleHandler;
        private readonly ITokenFactoryService _tokenFactoryService;
        private readonly IUserFindByUsernameQueryHandler _userFindByUsernameHandler;
        private readonly IUserTokenCreateHandler _userTokenCreateHandler;
        private readonly IUserTokenFindByRefreshQueryHandler _userTokenFindByRefreshTokenHandler;
        private readonly IUserPolicyQueryHandler _userPolicyQueryHandler;
        private readonly IUserLoginAddHandler _userLoginAddHandler;
        private readonly IUserLoginFindHandler _userLoginFindHandler;

        public LoginController(
            IUnitOfWork uow,
            ICaptchaGetSingleHandler captchaGetSingleHandler,
            ITokenFactoryService tokenFactoryService,
            IUserFindByUsernameQueryHandler userFindByUsernameHandler,
            IUserFindByUsernamePasswordHandler findUserByUsernamePasswordHandler,
            IUserTokenCreateHandler userTokenCreateHandler,
            IUserTokenFindByRefreshQueryHandler userTokenFindByRefreshTokenHandler,
            IUserPolicyQueryHandler userPolicyQueryHandler,
            IUserLoginAddHandler userLoginAddHandler,
            IUserLoginFindHandler userLoginFindHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _captchaGetSingleHandler = captchaGetSingleHandler;
            _captchaGetSingleHandler.NotNull(nameof(_captchaGetSingleHandler));

            _tokenFactoryService = tokenFactoryService;
            _tokenFactoryService.NotNull(nameof(_tokenFactoryService));

            _userFindByUsernameHandler = userFindByUsernameHandler;
            _userFindByUsernameHandler.NotNull(nameof(_userFindByUsernameHandler));

            _userTokenCreateHandler = userTokenCreateHandler;
            _userTokenCreateHandler.NotNull(nameof(_userTokenCreateHandler));

            _userTokenFindByRefreshTokenHandler = userTokenFindByRefreshTokenHandler;
            _userTokenFindByRefreshTokenHandler.NotNull(nameof(userTokenFindByRefreshTokenHandler));

            _userPolicyQueryHandler = userPolicyQueryHandler;
            _userPolicyQueryHandler.NotNull(nameof(_userPolicyQueryHandler));

            _userLoginAddHandler = userLoginAddHandler;
            _userLoginAddHandler.NotNull(nameof(_userLoginAddHandler));

            _userLoginFindHandler = userLoginFindHandler;
            _userLoginFindHandler.NotNull(nameof(_userLoginFindHandler));

            _userFindByPasswordHandler = findUserByUsernamePasswordHandler;
            _userFindByPasswordHandler.NotNull(nameof(_userFindByPasswordHandler));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("first-step")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<FirstStepOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseEnvelope<SecondStepOutput>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaceFirstStep([FromBody] FirstStepLoginInput loginInput, CancellationToken cancellationToken)
        {
            var (user, result) = await _userFindByPasswordHandler.Handle(loginInput, cancellationToken);
            if (!result || user is null)
            {
                return ClientError(MessageResources.UserNotFound);
            }

            //Policy
            var (userPolicy, resultPolicy) = await _userPolicyQueryHandler.Handle(loginInput, cancellationToken);
            if (!resultPolicy || !string.IsNullOrEmpty(userPolicy))
            {
                return ClientError(userPolicy);
            }

            if (!user.HasTwoStepVerification)
            {
                SecondStepOutput secondStepOutput = await GetSecondStepOutput(user, cancellationToken);
                return Ok(secondStepOutput);
            }
            FirstStepOutput output = await _userLoginAddHandler.Handle(loginInput, user);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(output, "second-step");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("second-step")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<SecondStepOutput>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaceSecondStep([FromBody] SecondStepLoginInput loginDto, CancellationToken cancellationToken)
        {
            UserLogin userLogin = await _userLoginFindHandler.Handle(loginDto, cancellationToken);
            if (userLogin == null)
            {
                return ClientError(MessageResources.InvalidConfirmCode);
            }
            SecondStepOutput secondStepOutput = await GetSecondStepOutput(userLogin.User, cancellationToken);
            return Ok(secondStepOutput);
        }
        private async Task<SecondStepOutput> GetSecondStepOutput(User user, CancellationToken cancellationToken)
        {
            JwtTokenData jwtData = await _tokenFactoryService.CreateJwtTokensAsync(user);
            await _userTokenCreateHandler.Handle(jwtData, null, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return new SecondStepOutput(jwtData.AccessToken, jwtData.RefreshToken);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh")]
        [ProducesResponseType(typeof(SecondStepOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshToken refreshToken, CancellationToken cancellationToken)
        {
            UserToken userToken = await _userTokenFindByRefreshTokenHandler.Handle(refreshToken, cancellationToken);
            if (userToken == null)
            {
                return Unauthorized();
            }
            string refreshSerial = _tokenFactoryService.GetRefreshTokenSerial(refreshToken.ToString());
            JwtTokenData jwtData = await _tokenFactoryService.CreateJwtTokensAsync(userToken.User);
            await _userTokenCreateHandler.Handle(jwtData, refreshSerial, cancellationToken);
            await _uow.SaveChangesAsync();
            return Ok(new SecondStepOutput(jwtData.AccessToken, jwtData.RefreshToken));
        }
    }
}