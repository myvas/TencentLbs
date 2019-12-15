using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myvas.AspNetCore.TencentLbs
{
    public class TencentLbsOptions
    {
        /// <summary>
        /// 腾讯LBS KEY（GUID）
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Used to communicate with the remote sms server.
        /// </summary>
        public HttpClient Backchannel { get; set; }

        /// <summary>
        /// Gets or sets timeout value in milliseconds for back channel communications with the remote sms server.
        /// </summary>
        public TimeSpan BackchannelTimeout { get; set; }

        /// <summary>
        /// Gets or sets the time limit for completing the sms operation/flow (15 minutes by default).
        /// </summary>
        public TimeSpan RemoteResponseTimeout { get; set; } = TimeSpan.FromMinutes(15);

        public virtual void Validate()
        {
            if (string.IsNullOrEmpty(Key))
                throw new ArgumentNullException(nameof(Key));
        }
    }
}
