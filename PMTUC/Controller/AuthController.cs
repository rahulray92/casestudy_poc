using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMT_BAL.Service;
using PMT_DAL.Interface;
using PMT_DAL.Models;
using PMTUC.Model;
using PMTUC.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMTUC.Controller
{
    /// <summary>
    /// 
    /// </summary>
 [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IAuthRepository<User> _user; 
       
        private readonly ILogger<AuthController> _logger;
        /// <summary>
        /// ManagerController
        /// </summary>
        /// <param name="user"></param>
        /// <param name="authService"></param>
        /// <param name="tasks"></param>
        /// <param name="taskService"></param>
        /// <param name="logger"></param>
        public AuthController(IAuthRepository<User> user, AuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _user = user;
           
            
            _logger = logger;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> login([FromBody] UserLoginRequest request)
        {
            var response = await _authService.Login(
                request.username, request.password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<List<int>>>> Register([FromQuery] string UserName, [FromQuery] string Password)
        {
            var response = await _authService.Register(
                new User { UserName =UserName }, Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
