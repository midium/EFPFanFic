using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EFPFanFic.UI.Selectors.CategorySelector.ViewModels.DTO;
using EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels.DTO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Diagnostics;
using EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels;
using System.Windows.Media;

namespace EFPFanFic.Business.Scapers.PageScrapers
{
    public class MainPageScraper
    {
        private const string _baseUri = "https://efpfanfic.net/{0}";
        private WebClient _webClient;
        private HtmlDocument _decoder;

        public MainPageScraper(WebClient webClient, HtmlDocument decoder)
        {
            _webClient = webClient;
            _decoder = decoder;
        }

        internal ObservableCollection<CategoryItemDTO> GetFanFicCategories()
        {
            try
            {
                bool scrapeSucceeded = true;

                ObservableCollection<CategoryItemDTO> result = new ObservableCollection<CategoryItemDTO>();

                byte[] mainPageHtml = _webClient.DownloadData(string.Format(_baseUri,string.Empty));
                string source = Encoding.GetEncoding("iso-8859-1").GetString(mainPageHtml, 0, mainPageHtml.Length - 1);
                source = WebUtility.HtmlDecode(source);
                _decoder.LoadHtml(source);

                HtmlNode fanFicNode = _decoder.DocumentNode.Descendants().Where(x => (x.Name == "table" &&
                                                                                    x.Attributes["align"] != null &&
                                                                                    x.Attributes["align"].Value.Contains("center"))).FirstOrDefault();

                if (fanFicNode != null)
                {
                    List<HtmlNode> categories = fanFicNode.Descendants().Where(x => (x.Name == "td" &&
                                                                                     x.Attributes["align"] != null &&
                                                                                     x.Attributes["align"].Value.Contains("left"))).ToList();
                    if (categories != null)
                    {
                        foreach (HtmlNode category in categories)
                        {
                            HtmlNode nameNode = category.Descendants().Where(x => (x.Name == "a" &&
                                                                                   x.Attributes["href"] != null)).FirstOrDefault();
                            HtmlNode countNode = category.Descendants().Where(x => (x.Name == "font")).FirstOrDefault();

                            string categoryName = string.Empty;
                            string categoryUri = string.Empty;
                            long categoryCount = long.MinValue;

                            if (nameNode != null)
                            {
                                categoryName = nameNode.InnerText;
                                categoryUri = nameNode.Attributes["href"].Value;

                                if (countNode != null)
                                    categoryCount = Convert.ToInt64(countNode.InnerText.Replace("(", "").Replace(")", "").ToString());

                                if (categoryName != string.Empty)
                                    result.Add(new CategoryItemDTO(categoryName, categoryUri, categoryCount));
                            }

                        }
                    }
                    else
                        scrapeSucceeded = false;

                }
                else
                    scrapeSucceeded = false;

                if (scrapeSucceeded == false)
                {
                    //TODO: Advise user that nothing has been found and disable UI
                }

                return result;
            } catch(Exception e)
            {
                return null;
            }

        }
    }
}
