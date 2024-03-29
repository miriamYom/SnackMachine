﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMachine.Report;

internal abstract class ReportBuilder
{
    string PATH;
    DateTime TodaysDate;

    protected string report;
    public abstract void AddEntry(string actionDescription);
    public abstract string GetReport();
}
