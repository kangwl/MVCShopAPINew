using System.Web.Http;

namespace ShopMVCAPINew.Controllers
{
    public class LoginController : ApiController
    {
        public LoginResult Post([FromBody] Models.User user) {

            LoginResult result = new LoginResult();
            if (!string.IsNullOrEmpty(user.UserID) && !string.IsNullOrEmpty(user.UserPass)) {
                result.code = 1;
                result.msg = "登录成功";
            }
            else {
                result.msg = "用户名和密码不能为空";
            }
            return result;
        }

        public class LoginResult {
            public LoginResult() {
                code = 0;
                msg = "登陆失败";
            }
            public int code { get; set; }
            public string msg { get; set; }
        }
    }
}
