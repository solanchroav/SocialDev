using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Presenters
{
    public static class Presenter
    {
        public static IActionResult Result<T>(this ControllerBase controller, Response<T> response) where T : class
        {
            AddHeaders(controller, response);
            if (!response.IsValid)
            {
                return RequestError(response);
            }

            return RequestSucess(response);
        }
        public static IActionResult RequestError<T>(Response<T> response) where T : class
        {
            return new JsonResult(response.Notifications)
            {
                StatusCode = (int)response.StatusCode
            };
        }
        public static IActionResult RequestSucess<T>(Response<T> response) where T : class
        {
            return new JsonResult(response.Content)
            {
                StatusCode = (int)response.StatusCode
            };
        }
        public static void AddHeaders<T>(ControllerBase controller, Response<T> response) where T : class
        {
            if (!response.Headers.Any())
            {
                return;
            }

            foreach (KeyValuePair<string, string> header in response.Headers)
            {
                controller.Response.Headers.Add(header.Key, header.Value);
            }
        }
    }
}
