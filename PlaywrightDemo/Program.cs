using Microsoft.Playwright;
using System.Text.RegularExpressions;
// 創建一個 Playwright 的 Instance
using var playwright = await Playwright.CreateAsync();
// 取得一個 Browser 的 Instance
await using var browser = await playwright.Chromium.LaunchAsync();
// 取得一個Page 的 Instance
var page = await browser.NewPageAsync();
// 前往 https://www.ptt.cc/bbs/BeautySalon/M.1654351685.A.0B7.html 這個網頁
await page.GotoAsync("https://www.everrichtohome.com/tw/67-%E8%BA%AB%E9%AB%94%E6%B8%85%E6%BD%94?page=1&show_count=48#page=1&show_count=48");
// 搭配css selector 取得 html 內的 text
var html = await page.InnerTextAsync(".load-category-items");
string pattern = @"(.+)\n((?:.|\n)*?)\n\nNT\$ (.+)\n\n立即購買";

RegexOptions options = RegexOptions.Multiline;

var matches = Regex.Matches(html, pattern, options);
foreach (Match m in matches)
{
    var group = m.Groups;
    Console.WriteLine(group[1].Value);
    Console.WriteLine(group[2].Value);
    Console.WriteLine(group[3].Value);
    Console.WriteLine();
}

// 顯示結果
//Console.WriteLine(html);
