using Autodesk.AdvanceSteel.Runtime;
using Autodesk.AdvanceSteel.DocumentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AdvanceSteel.CADAccess;
using Autodesk.AdvanceSteel.Profiles;
using Autodesk.AdvanceSteel.Geometry;
using Autodesk.AdvanceSteel.Modelling;

// using alias directive for AdvanceSteel
using ASTransactionManager = Autodesk.AdvanceSteel.CADAccess.TransactionManager;
using ASObjectId = Autodesk.AdvanceSteel.CADLink.Database.ObjectId;

// using alias directive for Autocad

namespace ADVSTemplate
{
    class Command
    {
        [CommandMethodAttribute("TEST_GROUP", "CreateElements", "CreateElements",
                                CommandFlags.Modal | CommandFlags.UsePickSet | CommandFlags.Redraw)]
        public void Create()
        {
            DocumentManager.LockCurrentDocument();
            Transaction t = ASTransactionManager.StartTransaction();

            // your code here

            t.Commit();
            DocumentManager.UnlockCurrentDocument();
        }
    }
}
