using Microsoft.AspNetCore.Http;

namespace IsAnAntipattern.Metrics
{
    public interface ISiteMetrics
    {
        void SubDomainCount(string subDomain);
        void ReferrerCount(HttpRequest request);
    }
}