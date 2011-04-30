using System;
using JsonExSerializer;

namespace Recorder
{
    [Serializable]
    public class PublicStats
    {
        [JsonExProperty("ghashes_ps")]
        public double GhashesPs { get; set; }

        [JsonExProperty("shares")]
        public ulong Shares { get; set; }

        [JsonExProperty("active_workers")]
        public int ActiveWorkers { get; set; }

        [JsonExProperty("round_duration")]
        public string RoundDuration { get; set; }

        [JsonExProperty("score")]
        public double Score { get; set; }

        [JsonExProperty("round_started")]
        public string RoundStarted { get; set; }

        [JsonExProperty("shares_cdf")]
        public double SharesCdf { get; set; }

        [JsonExProperty("getwork_ps")]
        public int GetworkPs { get; set; }
    }
}
