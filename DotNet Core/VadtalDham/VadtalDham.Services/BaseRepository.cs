using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VadtalDham.Model.Config;

namespace VadtalDham.Services
{
    public class BaseRepository
    {
        #region Fields
        public readonly IOptions<DataConfig> _dataConfig;
        #endregion

        #region Constructor
        BaseRepository(IOptions<DataConfig> dataConfig) { _dataConfig = dataConfig; }
        #endregion
    }
}
