﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayuiTemplate.Global
{
    public interface ILayDialogAware
    {
        event Action<ILayDialogResult> RequestClose;
        void OnDialogOpened(ILayDialogParameter parameters);
    }
}
