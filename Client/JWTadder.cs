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

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if(Global.jwt != String.Empty) request.Headers.Add("Authorization", "Bearer " + Global.jwt);
        return await base.SendAsync(request, cancellationToken);
    }
}