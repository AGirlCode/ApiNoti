namespace ApiNoti.Controllers
{
    public interface  IAccountController
    {
        /// <summary>
        /// Cập nhật deviceID
        /// </summary>
        /// <param name="clientCode"></param>
        /// <param name="deviceId"></param>
        /// <param name="userAgent"></param>
        /// <param name="appName"></param>
        /// <returns></returns>
        object UpdateDeviceInfo(string clientCode, string deviceId, string userAgent, string appName);
    }
}
