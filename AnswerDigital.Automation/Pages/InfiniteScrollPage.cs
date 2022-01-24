using Automation.Common;
using Automation.Common.Config;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using FluentAssertions;


namespace Automation.Pages
{
    public class InfiniteScrollPage : BasePage
    {
        private readonly AppConfig appConfig;
        public InfiniteScrollPage(ISeleniumContext context) : base(context)
        {
        }

        public By Page { get { return By.CssSelector("[class = 'jscroll-inner']"); } }
        public By ParagraphX(int X)
        { 
            string number = (X + 2).ToString();
            return By.XPath($"//div[@class='jscroll-added'][{number}]"); 
        }

        public void ScrollXAmount(int X)
        {
            int i = 0;
            while (i < X)
            {
                int pageHeight = 0;
                int previousPageHeight = pageHeight;
                pageHeight = this.GetElementHeight(Page);
                ScrollByHeight(pageHeight);
                // if the page height has changed then more content has appeared
                if (pageHeight > previousPageHeight) i++;
            }
        }

        public bool IsParagraphXDisplayed(int X)
        {
            return this.ElemenBytIsDisplayed(ParagraphX(X));
        }
    }
}
