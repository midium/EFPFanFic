using EFPFanFic.Business.Scapers.Entities.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels.DesignTime
{
    public class DTFanFicSelectorViewModel : FanFicSelectorViewModel
    {
        public DTFanFicSelectorViewModel() :
            base(new ObservableCollection<FanFicItemViewModel>()
            {
                new FanFicItemViewModel(new SolidColorBrush(Colors.Orange),"Mary Lloyd e il Voto Infrangibile", 
                "(Seguito di Mary Lloyd, la chiave e il volto del male). Un nuovo personaggio è entrato a far parte della leggendaria storia ed ora, che è sempre più forte e consapevole delle sue capacità, sarà impossibile uscirne! Buoni e cattivi, ma è così semplice? Nuove idee, nuove emozioni, nuovi ricordi...un'altra vita! (La lettura della storia precedente è indispensabile per comprendere la relazione tra i personaggi e la protagonista, ma se proprio non vi va potreste comunque riuscire a capire). (Seguito di Mary Lloyd, la chiave e il volto del male). Un nuovo personaggio è entrato a far parte della leggendaria storia ed ora, che è sempre più forte e consapevole delle sue capacità, sarà impossibile uscirne! Buoni e cattivi, ma è così semplice? Nuove idee, nuove emozioni, nuovi ricordi...un'altra vita! (La lettura della storia precedente è indispensabile per comprendere la relazione tra i personaggi e la protagonista, ma se proprio non vi va potreste comunque riuscire a capire)",
                "CaramelizedApple", "03/10/16", "17/10/17", "Avventura, Azione, Fantasy", 57, "In corso","What if?","Nessuno",
                "Draco Malfoy, Il trio protagonista, Nuovo personaggio, Un po' tutti, Voldemort","Draco/Ginny","Het",
                "Da VI libro alternativo", string.Empty),
                new FanFicItemViewModel(new SolidColorBrush(Colors.Red),"Scene da un fidanzamento", 
                "Mi dondolo sulla poltrona per qualche istante, richiamando alla mente gli ultimi mesi: ci è voluta tenacia perché Lily accettasse la mia proposta, per mesi lei ha rifiutato ogni volta che gliel'ho chiesto... Nota dell'autrice: per comprendere al meglio la trama è consigliata la lettura della serie in ordine cronologico",
                "Alessya", "03/10/16", "17/10/17", "Avventura, Azione, Fantasy", 57, "In corso","What if?","Nessuno",
                "Draco Malfoy, Il trio protagonista, Nuovo personaggio, Un po' tutti, Voldemort","Draco/Ginny","Het",
                "Da VI libro alternativo", string.Empty)
            }, 1, 4376,new List<EntityBase>()
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
