using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Collections.ObjectModel;
using EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels;
using System.Windows.Media;
using System.Text.RegularExpressions;
using EFPFanFic.Business.Scapers.Entities;
using System.Globalization;
using System.Diagnostics;

namespace EFPFanFic.Business.Scapers.PageScrapers
{
    public class FanFicsPageScraper
    {
        private const string _baseUri = "https://efpfanfic.net/{0}&offset={1}&pagina={2}&ratinglist={3}&charlist1={4}&charlist2={5}&genrelist={6}&warninglist1={7}&warninglist2={8}&completelist={9}&capitolilist={10}&colloclist={11}&tipocoplist={12}&coppielist={13}&avvertlist1={14}&avvertlist2={15}";
        private const string _fullStoryUri = "https://efpfanfic.net/printsave.php?action=printall&sid={0}";
        private readonly WebClient _webClient;
        private readonly HtmlDocument _decoder;
        private int _totalPages;
        private List<EntityBase> _ratingOptions = new List<EntityBase>();
        private List<EntityBase> _genresOptions = new List<EntityBase>();
        private List<EntityBase> _storyLengthOptions = new List<EntityBase>();
        private List<EntityBase> _storyStatusOptions = new List<EntityBase>();
        private List<EntityBase> _coupleTypesOptions = new List<EntityBase>();
        private List<EntityBase> _charactersOptions = new List<EntityBase>();
        private List<EntityBase> _couplesOptions = new List<EntityBase>();
        private List<EntityBase> _contextOptions = new List<EntityBase>();
        private List<EntityBase> _notesOptions = new List<EntityBase>();
        private List<EntityBase> _warnsOptions = new List<EntityBase>();

        public FanFicsPageScraper(WebClient webClient, HtmlDocument decoder)
        {
            _webClient = webClient;
            _decoder = decoder;
        }

        public int TotalPages { get => _totalPages; }
        public List<EntityBase> RatingOptions { get => _ratingOptions; }
        public List<EntityBase> GenresOptions { get => _genresOptions; }
        public List<EntityBase> StoryLengthOptions { get => _storyLengthOptions; }
        public List<EntityBase> StoryStatusOptions { get => _storyStatusOptions; }
        public List<EntityBase> CoupleTypesOptions { get => _coupleTypesOptions; }
        public List<EntityBase> CharactersOptions { get => _charactersOptions; }
        public List<EntityBase> CouplesOptions { get => _couplesOptions; }
        public List<EntityBase> ContextOptions { get => _contextOptions; }
        public List<EntityBase> NotesOptions { get => _notesOptions; }
        public List<EntityBase> WarnsOptions { get => _warnsOptions; }

        internal ObservableCollection<FanFicItemViewModel> GetFanFicStories(string fanFicsUri, int pageNumber)
        {
            return GetFanFicStories(fanFicsUri, pageNumber, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        }

        internal ObservableCollection<FanFicItemViewModel> GetFanFicStories(string fanFicsUri, int pageNumber, string rating, string genre, string storyLength, 
            string storyStatus, string coupleType, string character1, string character2, string couple, string context, string note, string warn, 
            string excludeNote, string excludeWarn)
        {
            ObservableCollection<FanFicItemViewModel> result = new ObservableCollection<FanFicItemViewModel>();

            try
            {
                bool scrapeSucceeded = true;
                int offset = (pageNumber - 1) * 15;

                string uri = string.Format(_baseUri, fanFicsUri, offset, pageNumber, rating, character1, character2, genre, note, excludeNote,
                    storyStatus, storyLength, context, coupleType, couple, warn, excludeWarn);

                byte[] mainPageHtml = _webClient.DownloadData(uri);
                string source = Encoding.GetEncoding("iso-8859-1").GetString(mainPageHtml, 0, mainPageHtml.Length - 1);
                source = WebUtility.HtmlDecode(source);
                _decoder.LoadHtml(source);

                HtmlNode fanFicsNodes = _decoder.DocumentNode.Descendants().FirstOrDefault(x => (x.Name == "div" &&
                                                                                    x.Attributes["id"] != null &&
                                                                                    x.Attributes["id"].Value.Contains("corpo")));

                if (fanFicsNodes != null)
                {
                    // Loading fan fics data
                    List<HtmlNode> fanFicsBlocks = fanFicsNodes.Descendants().Where(x => (x.Name == "div" &&
                                                                                     x.Attributes["class"] != null && 
                                                                                     x.Attributes["class"].Value.Contains("storybloc"))).ToList();
                    if (fanFicsBlocks != null)
                    {
                        foreach (HtmlNode fanFicBlock in fanFicsBlocks)
                        {
                            HtmlNode titleNode = fanFicBlock.Descendants().FirstOrDefault(x => (x.Name == "div" &&
                                                                                    x.Attributes["class"] != null &&
                                                                                    x.Attributes["class"].Value.Contains("titlestoria")));

                            HtmlNode descriptionNode = fanFicBlock.Descendants().FirstOrDefault(x => (x.Name == "div" &&
                                                                                    x.Attributes["class"] != null &&
                                                                                    x.Attributes["class"].Value.Contains("introbloc")));

                            HtmlNode detailsNode = fanFicBlock.Descendants().FirstOrDefault(x => (x.Name == "div" &&
                                                                                    x.Attributes["class"] != null &&
                                                                                    x.Attributes["class"].Value.Contains("notebloc")));


                            string fanFicTitle = string.Empty;
                            string fanFicUri = string.Empty;
                            string fanFicDescription = string.Empty;
                            string fanFicAuthor = string.Empty;
                            string fanFicStarted = string.Empty;
                            string fanFicUpdated = string.Empty;
                            string fanFicGenre = string.Empty;
                            SolidColorBrush fanFicRating = new SolidColorBrush(Colors.Transparent);
                            int fanFicCaps = 0;
                            string fanFicStatus = string.Empty;
                            string fanFicNotes = string.Empty;
                            string fanFicWarnings = string.Empty;
                            string fanFicCharacters = string.Empty;
                            string fanFicCouples = string.Empty;
                            string fanFicCoupleType = string.Empty;
                            string fanFicContext = string.Empty;

                            if (titleNode != null && titleNode.ChildNodes != null && titleNode.ChildNodes.Count>0)
                            {
                                fanFicTitle = titleNode.ChildNodes.FirstOrDefault().InnerText;
                                fanFicUri = titleNode.ChildNodes.FirstOrDefault().Attributes["href"].Value;

                                if (descriptionNode != null)
                                    fanFicDescription = descriptionNode.InnerText.Replace(Environment.NewLine," ");

                                if(detailsNode != null)
                                {
                                    fanFicAuthor = detailsNode.Descendants().Where(x => (x.Name == "a" &&
                                                                                        x.Attributes["href"] != null)).FirstOrDefault()?.InnerText;
                                     
                                    Match elementsFound = Regex.Match(detailsNode.InnerText.Replace(Environment.NewLine, "|").Replace("<br>", ""), "\\|.*\\|");
                                    if (elementsFound.Success)
                                    {
                                        string[] elements = elementsFound.Value.Split('|');

                                        foreach(string element in elements)
                                        {
                                            if(element.Trim() != string.Empty)
                                            {
                                                Match elementType = Regex.Match(element.Trim(), ".*\\:");
                                                Match elementValue = Regex.Match(element.Trim(), "\\:.*");
                                                if (elementType.Success && elementValue.Success)
                                                {
                                                    string elValue = elementValue.Value.Replace(":", "").Trim(); 
                                                    switch (elementType.Value.Trim().ToLower())
                                                    {
                                                        case "pubblicata:":
                                                            fanFicStarted = elValue;
                                                            break;
                                                        case "aggiornata:":
                                                            fanFicUpdated = elValue;
                                                            break;
                                                        case "rating:":
                                                            switch (elValue.ToLower())
                                                            {
                                                                case "arancione":
                                                                    fanFicRating = new SolidColorBrush(Colors.Orange);
                                                                    break;
                                                                case "rosso":
                                                                    fanFicRating = new SolidColorBrush(Colors.Red);
                                                                    break;
                                                                case "giallo":
                                                                    fanFicRating = new SolidColorBrush(Colors.Yellow);
                                                                    break;
                                                                case "verde":
                                                                    fanFicRating = new SolidColorBrush(Colors.Green);
                                                                    break;
                                                            }
                                                            
                                                            break;
                                                        case "genere:":
                                                            fanFicGenre = elValue;
                                                            break;
                                                        case "capitoli:":
                                                            Match caps = Regex.Match(elValue, @"\d+");
                                                            if(caps.Success)
                                                                fanFicCaps = Convert.ToInt32(caps.Value);
                                                            break;
                                                        case "tipo di coppia:":
                                                            fanFicCoupleType = elValue;
                                                            break;
                                                        case "note:":
                                                            fanFicNotes = elValue;
                                                            break;
                                                        case "avvertimenti:":
                                                            fanFicWarnings = elValue;
                                                            break;
                                                        case "personaggi:":
                                                            fanFicCharacters = elValue;
                                                            break;
                                                        case "coppie:":
                                                            fanFicCouples = elValue;
                                                            break;
                                                        case "contesto:":
                                                            fanFicContext = elValue;
                                                            break;

                                                    }
                                                } else
                                                {
                                                    if (element.Trim() != string.Empty)
                                                    {
                                                        fanFicStatus = element.Trim();
                                                    }
                                                }
                                            }

                                        }

                                        result.Add(new FanFicItemViewModel(fanFicRating,fanFicTitle,fanFicDescription,fanFicAuthor,fanFicStarted,
                                            fanFicUpdated,fanFicGenre,fanFicCaps,fanFicStatus,fanFicNotes,fanFicWarnings,fanFicCharacters,
                                            fanFicCouples,fanFicCoupleType,fanFicContext,fanFicUri));
                                        
                                    }
                                }
                                
                            }

                        }
                    }
                    else
                        scrapeSucceeded = false;

                    // Loading pages count
                    HtmlNode paginationNode = fanFicsNodes.Descendants().LastOrDefault(x => (x.Name == "div" &&
                                                                                     x.Attributes["style"] != null && 
                                                                                     x.Attributes["style"].Value.Contains("text-align:center;")));

                    HtmlNode pagesCountNote = paginationNode?.Descendants().FirstOrDefault(x => (x.Name == "big"))?.Descendants().LastOrDefault(x => (x.Name == "b"));

                    _totalPages = Convert.ToInt32(pagesCountNote?.InnerText);

                    // Loading searchable values
                    HtmlNode searchFormNode = fanFicsNodes.Descendants().FirstOrDefault(x => (x.Name == "form"));
                    if (searchFormNode != null)
                    {
                        _ratingOptions = GetOptions(fanFicsNodes, "ratinglist");
                        _genresOptions = GetOptions(fanFicsNodes,"genrelist");
                        _storyLengthOptions = GetOptions(fanFicsNodes, "capitolilist");
                        _storyStatusOptions = GetOptions(fanFicsNodes, "completelist");
                        _coupleTypesOptions = GetOptions(fanFicsNodes, "tipocoplist");
                        _charactersOptions = GetOptions(fanFicsNodes, "charlist1");
                        _couplesOptions = GetOptions(fanFicsNodes, "coppielist");
                        _contextOptions = GetOptions(fanFicsNodes, "colloclist");
                        _notesOptions = GetOptions(fanFicsNodes, "warninglist1");
                        _warnsOptions = GetOptions(fanFicsNodes, "avvertlist1");
                    }

                }
                else
                    scrapeSucceeded = false;

                if (!scrapeSucceeded)
                {
                    //TODO: Advise user that nothing has been found and disable UI
                }

                return result;
            } catch(Exception e)
            {
                return result;
            }
        }

        private List<EntityBase> GetOptions(HtmlNode searchFormNode, string optionName)
        {
            List<EntityBase> result = new List<EntityBase>();
            result.Add(new EntityBase(string.Empty, "Any"));

            HtmlNode ratingNode = searchFormNode.Descendants().FirstOrDefault(x => (x.Name == "select" &&
                                                                            x.Attributes["name"] != null &&
                                                                            x.Attributes["name"].Value.Contains(optionName)));
            if (ratingNode != null)
            {
                List<HtmlNode> optionsNodes = ratingNode.Descendants().Where(x => (x.Name == "option" &&
                                                                            x.Attributes["value"] != null &&
                                                                            x.Attributes["value"].Value.ToString() != string.Empty)).ToList();

                if (optionsNodes != null)
                    foreach (HtmlNode option in optionsNodes)
                    {
                        string value = string.Empty;
                        string name = string.Empty;

                        if (option.Attributes["value"].Value.ToString() != string.Empty)
                            value = option.Attributes["value"].Value.ToString();
                        if (option.InnerText == "Harry/Hermione") Debug.Print("");
                        name = option.InnerText;

                        result.Add(new EntityBase(value, name));
                    }
            }

            return result;

        }

        internal FullStoryData GetFanFicFullStory(string fanFicUri)
        {
            FullStoryData result = null;
            Match fanFicId = Regex.Match(fanFicUri, "\\=.*\\&");
            if(fanFicId.Success)
            {
                string uriId = fanFicId.Value.Replace("=", string.Empty).Replace("&", string.Empty);
                try
                {
                    byte[] mainPageHtml = _webClient.DownloadData(string.Format(_fullStoryUri, uriId));
                    string source = Encoding.GetEncoding("Windows-1252").GetString(mainPageHtml, 0, mainPageHtml.Length - 1);
                    source = WebUtility.HtmlDecode(source.Replace('\u2019','\'').Replace('\u8217','\'').Replace('\u8017','\''));
                    _decoder.LoadHtml(source);

                    foreach(HtmlNode imgNode in _decoder.DocumentNode.Descendants().Where(x => (x.Name == "img" || x.Name == "hr")).ToList())
                        imgNode.Remove();

                    HtmlNode styleNode = _decoder.DocumentNode.Descendants().FirstOrDefault(x => (x.Name == "link" &&
                                                                    x.Attributes["rel"] != null &&
                                                                    x.Attributes["rel"].Value.Contains("stylesheet")));

                    string cssStyle = string.Empty;
                    if (styleNode != null && styleNode.Attributes["href"] != null)
                        cssStyle = styleNode.Attributes["href"].Value.ToString();

                    return new FullStoryData(_decoder.DocumentNode.InnerHtml, cssStyle);

                } catch(Exception e)
                {
                    return null;
                }
            }

            return result;
        }
    }
}
