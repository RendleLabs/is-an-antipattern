using App.Metrics;
using App.Metrics.Counter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebSockets.Internal;

namespace IsAnAntipattern.Metrics
{
    public sealed class SiteMetrics : ISiteMetrics
    {
        private readonly IMetrics _metrics;
        
        private static readonly CounterOptions SubDomainCounter = new CounterOptions
        {
            Name = "sub_domain",
            MeasurementUnit = Unit.Calls,
            ResetOnReporting = true
        };

        private static readonly CounterOptions ReferrerCounter = new CounterOptions
        {
            Name = "referrer_count",
            MeasurementUnit = Unit.Calls,
            ResetOnReporting = true
        };

        public SiteMetrics(IMetrics metrics)
        {
            _metrics = metrics;
        }

        public void SubDomainCount(string subDomain)
        {
            var tags = new MetricTags("sub", subDomain);
            _metrics.Measure.Counter.Increment(SubDomainCounter, tags);
        }

        public void ReferrerCount(HttpRequest request)
        {
            if (!request.Headers.TryGetValue("Referer", out var header)) return;
            
            var referrer = header.ToString();
            if (string.IsNullOrWhiteSpace(referrer)) return;
            
            var tags = new MetricTags("referrer", referrer);
            _metrics.Measure.Counter.Increment(ReferrerCounter, tags);
        }
    }
}