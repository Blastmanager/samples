using Sample.Contractor.Models.Responses;

namespace Sample.Contractor;

public class BmClient
{
    private readonly HttpClient _httpClient;
    private const string ContractorUri = "api/Contractor/";
    private const string GetProjectsUri = "GetProjects";
    private const string GetMisfiresByFoundDateUri = "GetMisfiresByFoundDate";
    private const string GetMisfiresByLastChangedUri = "GetMisfiresByLastChanged";
    private const string GetBlastReportsByBlastDateUri = "GetBlastReportsbyBlastDate";
    private const string GetBlastReportsByLastChangedUri = "GetBlastReportsByLastChanged";

    public BmClient(IHttpClientFactory httpClient) => _httpClient = httpClient.CreateClient();

    /// <summary>
    /// Get projects
    /// </summary>
    /// <param name="onlyActive">Whether to only get active projects or not</param>
    /// <returns></returns>
    public async ValueTask<GetProjectsResponse?> GetProjects(bool onlyActive)
    {
        var response = await _httpClient.GetAsync($"{ContractorUri}{GetProjectsUri}?onlyActive={onlyActive}");
        response.EnsureSuccessStatusCode();
        var value = await response.Content.ReadFromJsonAsync<GetProjectsResponse>();
        return value;
    }
    
    /// <summary>
    /// Get list of misfires by found date
    /// </summary>
    /// <param name="from"><see cref="DateTime"/> to go from</param>
    /// <param name="to"><see cref="DateTime"/> to go to</param>
    /// <returns></returns>
    public async ValueTask<List<GetMisfireResponse>> GetMisfiresByFoundDate(DateTime from, DateTime to)
    {
        if (from > to) throw new ArgumentException("From date must be before to date");
        var response = await _httpClient
            .GetAsync($"{ContractorUri}{GetMisfiresByFoundDateUri}?from={from:YYYY-MM-DDTHH:mm:ss}&to={to:YYYY-MM-DDTHH:mm:ss}");
        response.EnsureSuccessStatusCode();
        var value = await response.Content.ReadFromJsonAsync<List<GetMisfireResponse>>();
        return value;
    }
    
    /// <summary>
    /// Get list of misfires by last changed
    /// </summary>
    /// <param name="from"><see cref="DateTime"/> to go from</param>
    /// <param name="to"><see cref="DateTime"/> to go to</param>
    /// <returns></returns>
    public async ValueTask<List<GetMisfireResponse>> GetMisfiresByLastChanged(DateTime from, DateTime to)
    {
        if (from > to) throw new ArgumentException("From date must be before to date");
        var response = await _httpClient
            .GetAsync($"{ContractorUri}{GetMisfiresByLastChangedUri}?from={from:YYYY-MM-DDTHH:mm:ss}&to={to:YYYY-MM-DDTHH:mm:ss}");
        response.EnsureSuccessStatusCode();
        var value = await response.Content.ReadFromJsonAsync<List<GetMisfireResponse>>();
        return value;
    }
    
    /// <summary>
    /// Get list of blast reports by blast date
    /// </summary>
    /// <param name="from"><see cref="DateTime"/> to go from</param>
    /// <param name="to"><see cref="DateTime"/> to go to</param>
    /// <returns></returns>
    public async ValueTask<List<BlastReportsResponse>> GetBlastReportsByBlastDate(DateTime from, DateTime to)
    {
        if(from > to) throw new ArgumentException("From date must be before to date");
        var response = await _httpClient
            .GetAsync($"{ContractorUri}{GetBlastReportsByBlastDateUri}?from={from:YYYY-MM-DDTHH:mm:ss}&to={to:YYYY-MM-DDTHH:mm:ss}");
        response.EnsureSuccessStatusCode();
        var value = await response.Content.ReadFromJsonAsync<List<BlastReportsResponse>>();
        return value;
    }
    
    /// <summary>
    /// Get list of blast reports by last changed
    /// </summary>
    /// <param name="from"><see cref="DateTime"/> to go from</param>
    /// <param name="to"><see cref="DateTime"/> to go to</param>
    /// <returns></returns>
    public async ValueTask<List<BlastReportsResponse>> GetBlastReportsByLastChanged(DateTime from, DateTime to)
    {
        if (from > to) throw new ArgumentException("From date must be before to date");
        var response = await _httpClient
            .GetAsync($"{ContractorUri}{GetBlastReportsByLastChangedUri}?from={from:YYYY-MM-DDTHH:mm:ss}&to={to:YYYY-MM-DDTHH:mm:ss}");
        response.EnsureSuccessStatusCode();
        var value = await response.Content.ReadFromJsonAsync<List<BlastReportsResponse>>();
        return value;
    }
}