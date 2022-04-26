using System.Net;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Reflection.Metadata;

namespace lda.Client;

public class JWTadder : DelegatingHandler
{
    private IJSRuntime jsr;
    public JWTadder(IJSRuntime _jsr)
    {
        jsr = _jsr;
    }
    
    private async Task<string?> GetJWT()
    {
        return await jsr.InvokeAsync<string>("sessionStorage.getItem", "jwt").ConfigureAwait(false);
    }
    
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string? jwt = await GetJWT();

        if(jwt != null) request.Headers.Add("Authorization", "Bearer " + jwt);
        return await base.SendAsync(request, cancellationToken);
    }
}