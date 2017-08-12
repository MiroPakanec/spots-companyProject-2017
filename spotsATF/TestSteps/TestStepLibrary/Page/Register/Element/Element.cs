using System;
using System.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using spotsATF.TestSteps.Interfaces;

namespace spotsATF.TestSteps.TestStepLibrary.Page.Register.Element
{
    public class Element
    {
        private bool _elementHasSelector;
        private string _id;
        private string _class;
        private string _tag;

        public Element WithId(string id)
        {
            _id = id;
            _elementHasSelector = true;
            return this;
        }

        public Element WithClass(string elementClass)
        {
            _class = elementClass;
            _elementHasSelector = true;
            return this;
        }

        public Element WithTag(string tag)
        {
            _tag = tag;
            _elementHasSelector = true;
            return this;
        }

        public IActionTestStep EnterValue(string value)
        {
            return new ActionTestStep(driver =>
            {
                if (_elementHasSelector == false)
                    throw new NoNullAllowedException("Element selector cannot be null.");

                if (_id != null)
                {
                    driver.FindElement(By.Id(_id)).SendKeys(value);
                }
                else if (_class != null)
                {
                    driver.FindElement(By.Id(_class)).SendKeys(value);
                }
            });
        }

        public IActionTestStep Click
        {
            get
            {
                return new ActionTestStep(driver =>
                {
                    if (_elementHasSelector == false)
                        throw new NoNullAllowedException("Element selector cannot be null.");

                    if (_id != null)
                    {
                        driver.FindElement(By.Id(_id)).Click();
                    }
                    else if (_class != null)
                    {
                        driver.FindElement(By.Id(_class)).Click();
                    }
                });
            }
        }

        public IActionTestStep ClickAndWait(TimeSpan delay)
        {
            return new ActionTestStep(driver =>
            {
                if (_elementHasSelector == false)
                    throw new NoNullAllowedException("Element selector cannot be null.");

                if (_id != null)
                {
                    driver.FindElement(By.Id(_id)).Click();
                }
                else if (_class != null)
                {
                    driver.FindElement(By.Id(_class)).Click();
                }
                driver.Manage().Timeouts().ImplicitlyWait(delay);
            });

        }

        public IVerificationTestStep IsVisible
        {
            get
            {
                if (_elementHasSelector == false)
                    throw new NoNullAllowedException("Element selector cannot be null.");

                return new VerificationTestStep(driver =>
                {
                    if (_id != null)
                    {
                        Assert.IsTrue(driver.FindElement(By.Id(_id)).Displayed);
                    }
                    if (_class != null)
                    {
                        Assert.IsTrue(driver.FindElement(By.ClassName(_class)).Displayed);
                    }
                });
            }
        }

        public IVerificationTestStep IsEnabled
        {
            get
            {
                if (_elementHasSelector == false)
                    throw new NoNullAllowedException("Element selector cannot be null.");

                return new VerificationTestStep(driver =>
                {
                    if (_id != null)
                    {
                        Assert.IsTrue(driver.FindElement(By.Id(_id)).Enabled);
                    }
                    if (_class != null)
                    {
                        Assert.IsTrue(driver.FindElement(By.ClassName(_class)).Enabled);
                    }
                });
            }
        }

        public IVerificationTestStep IsSelected
        {
            get
            {
                if (_elementHasSelector == false)
                    throw new NoNullAllowedException("Element selector cannot be null.");

                return new VerificationTestStep(driver =>
                {
                    if (_id != null)
                    {
                        Assert.IsTrue(driver.FindElement(By.Id(_id)).Selected);
                    }
                    if (_class != null)
                    {
                        Assert.IsTrue(driver.FindElement(By.ClassName(_class)).Selected);
                    }                   
                });
            }
        }

        public IVerificationTestStep HasValueEqualTo(string value)
        {
            if (_elementHasSelector == false)
                throw new NoNullAllowedException("Element selector cannot be null.");

            return new VerificationTestStep(driver =>
            {
                if (_id != null)
                {
                    Assert.IsTrue(driver.FindElement(By.Id(_id)).GetAttribute("value").Equals(value));
                }

                if (_class != null)
                {
                    Assert.IsTrue(driver.FindElement(By.ClassName(_class)).GetAttribute("value").Equals(value));
                }
                if (_tag != null)
                {
                    Assert.IsTrue(driver.FindElement(By.TagName(_tag)).Text.Equals(value));
                }
            });
        }
    }
}
