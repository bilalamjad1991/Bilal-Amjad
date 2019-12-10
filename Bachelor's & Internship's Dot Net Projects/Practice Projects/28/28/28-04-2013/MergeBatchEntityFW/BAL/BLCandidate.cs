using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using DAL;


namespace BAL
{
    public class BLCandidate
    {
        public List<Candidates> ListCandidates()
        {
            dlCandidate obj = new dlCandidate();
            return obj.ListCandidates();
        }
    }
}
