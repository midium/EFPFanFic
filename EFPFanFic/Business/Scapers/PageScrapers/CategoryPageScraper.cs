using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Collections.ObjectModel;
using EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels.DTO;
using System.Text.RegularExpressions;

namespace EFPFanFic.Business.Scapers.PageScrapers
{
    public class CategoryPageScraper
    {
        private const string _baseUri = "https://efpfanfic.net/{0}";
        private WebClient _webClient;
        private HtmlDocument _decoder;

        public CategoryPageScraper(WebClient webClient, HtmlDocument decoder)
        {
            _webClient = webClient;
            _decoder = decoder;
        }

        internal ObservableCollection<SubCategoryItemDTO> GetFanFicSubCategories(string SubCategoryUri)
        {
            try
            {
                bool scrapeSucceeded = true;

                ObservableCollection<SubCategoryItemDTO> result = new ObservableCollection<SubCategoryItemDTO>();

                byte[] mainPageHtml = _webClient.DownloadData(string.Format(_baseUri, SubCategoryUri));
                string source = Encoding.GetEncoding("iso-8859-1").GetString(mainPageHtml, 0, mainPageHtml.Length - 1);
                source = WebUtility.HtmlDecode(source);
                _decoder.LoadHtml(source);

                HtmlNode subCategoriesNodes = _decoder.DocumentNode.Descendants().Where(x => (x.Name == "table" &&
                                                                                    x.Attributes["align"] != null &&
                                                                                    x.Attributes["align"].Value.Contains("center"))).FirstOrDefault();

                if (subCategoriesNodes != null)
                {
                    List<HtmlNode> subCategories = subCategoriesNodes.Descendants().Where(x => (x.Name == "div" &&
                                                                                     x.Attributes["style"] != null)).ToList();
                    if (subCategories != null)
                    {
                        foreach (HtmlNode subCategory in subCategories)
                        {
                            HtmlNode nameNode = subCategory.Descendants().Where(x => (x.Name == "a" &&
                                                                                   x.Attributes["href"] != null)).FirstOrDefault();
                            HtmlNode authorNode = subCategory.Descendants().Where(x => (x.Name == "font")).FirstOrDefault();

                            string subCategoryName = string.Empty;
                            string subCategoryAuthor = string.Empty;
                            string subCategoryUri = string.Empty;
                            long subCategoryCount = long.MinValue;

                            if (nameNode != null)
                            {
                                subCategoryName = nameNode.InnerText;
                                subCategoryUri = nameNode.Attributes["href"].Value;

                                Match countTextMatch = Regex.Match(subCategory.InnerText.Replace(subCategoryName,""), "\\((.*?)\\)");
                                if (countTextMatch.Success)
                                    subCategoryCount = Convert.ToInt64(countTextMatch.Value.Replace("(", "").Replace(")",""));

                                if (authorNode != null)
                                    subCategoryAuthor = authorNode.InnerText;

                                if (subCategoryName != string.Empty)
                                    result.Add(new SubCategoryItemDTO(subCategoryName, subCategoryAuthor, subCategoryUri, subCategoryCount));
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
