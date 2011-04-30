using System;
using JsonExSerializer;

namespace Recorder
{
    [Serializable]
    public class ApiData
    {
        [JsonExProperty("username")]
        public string Username { get; set; }

        [JsonExProperty("wallet")]
        public string Wallet { get; set; }

        [JsonExProperty("send_threshold")]
        public double SendThreshold { get; set; }

        [JsonExProperty("confirmed_reward")]
        public double ConfirmedReward { get; set; }

        [JsonExProperty("unconfirmed_reward")]
        public double UnconfirmedReward { get; set; }

        [JsonExProperty("estimated_reward")]
        public double EstimatedReward { get; set; }
    }
}
