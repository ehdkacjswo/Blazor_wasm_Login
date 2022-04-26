using System.Net;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Reflection.Metadata;

namespace lda.Client;

public class JWTadder : DelegatingHandler
{
    private IJSRuntime jsr;
    private IGlobal global;
    public JWTadder(IJSRuntime _jsr, IGlobal _global)
    {
        jsr = _jsr;
        global = _global;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string jwt = global.get_jwt();
        if(!String.IsNullOrEmpty(jwt)) request.Headers.Add("Authorization", "Bearer " + jwt);
        return await base.SendAsync(request, cancellationToken);
    }
}