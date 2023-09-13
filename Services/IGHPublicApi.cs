using MinimalAPIDemoByJiahuaTong.Dto;

namespace MinimalAPIDemoByJiahuaTong.Services
{
    public interface IGHPublicApi
    {
        Task<IEnumerable<GithubUserInfo>?> GetUserInfoByUserNamesAsync(List<string> userNames);
    }
}
