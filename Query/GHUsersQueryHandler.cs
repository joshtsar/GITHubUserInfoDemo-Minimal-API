using MediatR;

using MinimalAPIDemoByJiahuaTong.Dto;
using MinimalAPIDemoByJiahuaTong.Services;

namespace MinimapAPIDemoByJiahuaTong.Query
{
    public record GetUsersQuery(List<string> UserNames) : IRequest<IEnumerable<GithubUserInfo>>;
    public class GHUsersQueryHandler 
    : IRequestHandler<GetUsersQuery, IEnumerable<GithubUserInfo>?>
    {
        private readonly IGHPublicApi _githubPublicApiService;
        public GHUsersQueryHandler(IGHPublicApi githubPublicApiService)
        {
                _githubPublicApiService = githubPublicApiService;
        }

        public Task<IEnumerable<GithubUserInfo>?> Handle(GetUsersQuery req, CancellationToken ctk)
        {
            ctk.ThrowIfCancellationRequested();
            return _githubPublicApiService.GetUserInfoByUserNamesAsync(req.UserNames);
        }
    }
}
