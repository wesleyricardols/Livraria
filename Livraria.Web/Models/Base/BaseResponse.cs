namespace Livraria.Web.Models.Base
{
    public class BaseResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        #region Constructor

        public BaseResponse(bool status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        #endregion
    }
}
