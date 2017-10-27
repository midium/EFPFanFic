using EFPFanFic.Business.Scapers.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.UI.Search.ViewModels.DesignTime
{
    public class DTFanFicSearcherViewModel : FanFicSearcherViewModel
    {
        public DTFanFicSearcherViewModel() : base(new List<EntityBase>()
        {
            new EntityBase("1", "Verde"), new EntityBase("2", "Rosso")
        },
        new List<EntityBase>()
        {
            new EntityBase("1", "Romantico"), new EntityBase("2", "Avventura")
        },
        new List<EntityBase>()
        {
            new EntityBase("1", "One Shot"), new EntityBase("2", "Long story")
        },
        new List<EntityBase>()
        {
            new EntityBase("1", "In corso"), new EntityBase("2", "Terminata")
        },
        new List<EntityBase>()
        {
            new EntityBase("1", "Het"), new EntityBase("2", "Yuri")
        },
        new List<EntityBase>()
        {
            new EntityBase("1", "Harry Potter"), new EntityBase("2", "Hermione Granger")
        },
        new List<EntityBase>()
        {
            new EntityBase("1", "Harry/Hermione"), new EntityBase("2", "Hermione/Ron")
        },
        new List<EntityBase>()
        {
            new EntityBase("1", "Primo libro"), new EntityBase("2", "Post lotta finale")
        },
        new List<EntityBase>()
        {
            new EntityBase("1", "Nessuna"), new EntityBase("2", "Contenuto esplicito")
        },
        new List<EntityBase>()
        {
            new EntityBase("1", "Nessuno"), new EntityBase("2", "PG18")
        })
        {

        }

    }
}
