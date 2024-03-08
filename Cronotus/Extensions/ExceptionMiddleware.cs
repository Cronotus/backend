using Contracts;
using Entities.ErrorModel;
using Shared.Exceptions;
namespace Cronotus.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (EventEndedException ex)
            {
                _logger.LogError($"Request failed on {nameof(EventEndedException)} with error {ex.Message} with code {StatusCodes.Status409Conflict}");
                await HandleExceptionAsync(httpContext, StatusCodes.Status409Conflict, ex.Message);
            }
            catch (EventNotFoundException ex)
            {
                _logger.LogError($"Request failed on {nameof(EventNotFoundException)} with error {ex.Message} with code {StatusCodes.Status404NotFound}");
                await HandleExceptionAsync(httpContext, StatusCodes.Status404NotFound, ex.Message);
            }
            catch (OrganizerAlreadyExistsException ex)
            {
                _logger.LogError($"Request failed on {nameof(OrganizerAlreadyExistsException)} with error {ex.Message} with code {StatusCodes.Status409Conflict}");
                await HandleExceptionAsync(httpContext, StatusCodes.Status409Conflict, ex.Message);
            }
            catch (OrganizerNotFoundException ex) 
            {
                _logger.LogError($"Request failed on {nameof(OrganizerNotFoundException)} with error {ex.Message} with code {StatusCodes.Status404NotFound}");
                await HandleExceptionAsync(httpContext, StatusCodes.Status404NotFound, ex.Message);
            }
            catch (PlayerAlreadyExistsException ex)
            {
                _logger.LogError($"Request failed on {nameof(PlayerAlreadyExistsException)} with error {ex.Message} with code {StatusCodes.Status409Conflict}");
                await HandleExceptionAsync(httpContext, StatusCodes.Status409Conflict, ex.Message);
            }
            catch (PlayerAlreadySignedUpToEventException ex)
            {
                _logger.LogError($"Request failed on {nameof(PlayerAlreadySignedUpToEventException)} with error {ex.Message} with code {StatusCodes.Status409Conflict}");
                await HandleExceptionAsync(httpContext, StatusCodes.Status409Conflict, ex.Message);
            }
            catch (PlayerNotFoundException ex)
            {
                _logger.LogError($"Request failed on {nameof(PlayerNotFoundException)} with error {ex.Message} with code {StatusCodes.Status404NotFound}");
                await HandleExceptionAsync(httpContext, StatusCodes.Status404NotFound, ex.Message);
            }
            catch (PlayerNotSignedUpException ex)
            {
                _logger.LogError($"Request failed on {nameof(PlayerNotSignedUpException)} with error {ex.Message} with code {StatusCodes.Status409Conflict}");
                await HandleExceptionAsync(httpContext, StatusCodes.Status409Conflict, ex.Message);
            }
            catch (SportNotFoundException ex)
            {
                _logger.LogError($"Request failed on {nameof(SportNotFoundException)} with error {ex.Message} with code {StatusCodes.Status404NotFound}");
                await HandleExceptionAsync(httpContext, StatusCodes.Status404NotFound, ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError($"Request failed on {nameof(UserNotFoundException)} with error {ex.Message} with code {StatusCodes.Status404NotFound}");
                await HandleExceptionAsync(httpContext, StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Request failed on {nameof(Exception)} with error {ex.Message} with code {StatusCodes.Status500InternalServerError}");
                await HandleExceptionAsync(httpContext, StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, int statusCode, string errorMessage)
        {
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                message = errorMessage
            }.ToString());
        }
    }
}
