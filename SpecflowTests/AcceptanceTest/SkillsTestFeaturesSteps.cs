using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]

    public class SkillsTestFeaturesSteps:Utils.Start
    {
        [Given(@"i click on skill tab in profile page")]
        public void GivenIClickOnSkillTabInProfilePage()
        {
            Thread.Sleep(1500);
            // Click on skill tab
            Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Skills')]")).Click();
       
        }

        [When(@"Added a new skill")]
        public void WhenAddedANewSkill()
        {
            Thread.Sleep(1500);
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//div[@class='ui teal button'][contains(.,'Add New')]")).Click();

            //Add skill
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("selenium c#");

            //Click on skill Level
            Driver.driver.FindElement(By.Name("level")).Click();

            //Choose the skill level (intermediate)
            Driver.driver.FindElement(By.XPath("//option[@value='Intermediate']")).Click();


            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")).Click();

        }

        [When(@"i click on Edit button")]
        public void WhenIClickOnEditButton()
        {
            //click on edit button

            //Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]")).Click();

            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1500);
            CommonMethods.test = CommonMethods.extent.StartTest("Edit a skill");
            try
            {
                Thread.Sleep(1000);


                var table = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table")); //table

                var skillsList = table.FindElements(By.TagName("tbody")).ToList();   //all rows picked

                var isFound = false;

                for (int i = 1; i <= skillsList.Count; i++)
                {

                    var oldskill = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));  //each row and coloum

                    //click on edit button with specific row and column

                    if (oldskill.Text == "selenium c#")
                    {
                        isFound = true;

                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]")).Click();   //edit button



                        break;
                    }
                }

                if (isFound)
                {

                    //Add skill {edit value update from (selenium C#)}
                    IWebElement skill = Driver.driver.FindElement(By.XPath("//input[@name='name']"));
                    skill.Clear();
                    skill.SendKeys("Manual Testing");

                    //Click on skill Level
                    Driver.driver.FindElement(By.Name("level")).Click();

                    //Choose the skill level (Expert) {edit value update}
                    Driver.driver.FindElement(By.XPath("//option[@value='Expert']")).Click();
                    //Wait
                    Thread.Sleep(1500);

                    //click on update button
                    IWebElement update = Driver.driver.FindElement(By.XPath("//input[@value='Update']"));
                    update.Click();
                }
                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed, skill not found");
                }


            }
            catch (Exception ex)
            {
                CommonMethods.test.Log(LogStatus.Fail, $"Test Failed due to exception. {ex.Message}");
                //  Assert.Fail(ex.Message);

            }
        }

        [When(@"I click on delete button")]
        public void WhenIClickOnDeleteButton()
        {

            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1500);
            CommonMethods.test = CommonMethods.extent.StartTest("Edit a skill");

            try
            {
                Thread.Sleep(1000);


                var table = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table")); //table

                var skillsList = table.FindElements(By.TagName("tbody")).ToList();   //all rows picked



                for (int i = 1; i <= skillsList.Count; i++)
                {

                    var skillname = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));  //each row and coloum

                    //click on delete button on specific row 

                    if (skillname.Text == "selenium java")
                    {


                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]")).Click();   //delete button

                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                CommonMethods.test.Log(LogStatus.Fail, $"Test Failed due to exception. {ex.Message}");
                //  Assert.Fail(ex.Message);

            }
        }

        [Then(@"the skill should be displayed on the list")]
        public void ThenTheSkillShouldBeDisplayedOnTheList()
        {

            CommonMethods.ExtentReports();
            Thread.Sleep(1000);
            CommonMethods.test = CommonMethods.extent.StartTest("Add a skill");

            try
            {
                Thread.Sleep(1000);


                var table = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));

                var skillsList = table.FindElements(By.TagName("tbody")).ToList();

                for (int i = 1; i <= skillsList.Count; i++)
                {

                    var skill = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));

                    //create test cases
                    if (skill.Text == "selenium c#")
                    {

                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a skill Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
                        break;
                    }
                    else
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Skill is not added");
                        //Assert.Fail("failed");
                    }



                }
            }
            catch (Exception ex)
            {
                CommonMethods.test.Log(LogStatus.Fail, $"Test Failed due to exception. {ex.Message}");
                //  Assert.Fail(ex.Message);

            }
        }

        [Then(@"the value should be Edited on my listings")]
        public void ThenTheValueShouldBeEditedOnMyListings()
        {
            try
            {
                Thread.Sleep(1000);


                var table = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));

                var skillsList = table.FindElements(By.TagName("tbody")).ToList();

                for (int i = 1; i <= skillsList.Count; i++)
                {

                    var skill = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));

                    //create test cases
                    if (skill.Text == "Manual Testing")
                    {

                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited a skill Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillEdited");
                        break;
                    }
                    else
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Code not edited");
                        //Assert.Fail("failed-code not edited");
                    }



                }
            }
            catch (Exception ex)
            {
                CommonMethods.test.Log(LogStatus.Fail, $"Test Failed due to exception. {ex.Message}");
                //  Assert.Fail(ex.Message);

            }
        }

        [Then(@"The value should be deleted on my listings")]
        public void ThenTheValueShouldBeDeletedOnMyListings()
        {
            try
            {
                Thread.Sleep(1000);


                var table = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));   //table

                var skillsList = table.FindElements(By.TagName("tbody")).ToList();

                for (int i = 1; i <= skillsList.Count; i++)
                {

                    var skill = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));  //each row with coloum

                    //create test cases
                    if (skill.Text == "selenium java")
                    {

                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited a skill Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillDeleted");
                        break;
                    }
                    else
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Code not deleted");
                        //Assert.Fail("failed");
                    }



                }
            }
            catch (Exception ex)
            {
                CommonMethods.test.Log(LogStatus.Fail, $"Test Failed due to exception. {ex.Message}");
                //  Assert.Fail(ex.Message);

            }
        }
    }
}
