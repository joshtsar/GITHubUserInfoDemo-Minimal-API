using Carter;

using MediatR;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using MinimalAPIDemoByJiahuaTong.Dto;

using MinimapAPIDemoByJiahuaTong.Query;

using Swashbuckle.AspNetCore.Annotations;

namespace MinimapAPIDemoByJiahuaTong.EndPoints
{
    public class GitHubUsersEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/usersInfoByNames", GetUsersAsync);
        }
        [SwaggerOperation(Summary = "[Note:Input User Names delimited by ,]")]
        public static async Task<Results<Ok<IEnumerable<GithubUserInfo>>,NotFound<string>>> GetUsersAsync(
            [FromQuery] string UserNameList,
            [FromServices]ISender sender)
        {
            if (!string.IsNullOrEmpty(UserNameList.Trim()))
            {
                var req = new GetUsersQuery(UserNameList.Split(',',StringSplitOptions.RemoveEmptyEntries).ToList());
                var results = await sender.Send(req);

                if (results?.Count() > 0)
                    return TypedResults.Ok(results);
                else
                    return TypedResults.NotFound("No valid users' info found");
            }
            else
                throw new ApplicationException("No valid User Name(s) provided.");

        }
    }
}
