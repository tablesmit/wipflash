﻿using System.Collections.Generic;
using System.Windows.Automation;
using NUnit.Framework;
using WiPFlash.Components;
using WiPFlash.Examples.ExampleUtils;
using WiPFlash.Framework;

namespace WiPFlash.Examples.Component
{
    [TestFixture]
    public class MenuBehaviour : AutomationElementWrapperExamples<Menu>
    {
        [Test]
        public void ShouldProvideSubMenus()
        {
            var menu = CreateWrapper();
            var subMenu = menu.Find<Menu>("tabMenu");
            var items = new List<string>(subMenu.Items);
            Assert.True(items.Contains("TabPresenter[History]"));
            Assert.True(items.Contains("TabPresenter[Accessories]"));
        }

        protected override Menu CreateWrapperWith(AutomationElement element, string name)
        {
            return new Menu(element, name);
        }

        protected override Menu CreateWrapper()
        {
            _window = LaunchPetShopWindow();
            return _window.Find<Menu>("mainMenu");
        }

        [Test]
        public void ShouldAllowMeToWaitUntilTheSelectionOrTheItemsChange()
        {
            GivenThisWillHappenAtSomePoint(menu => menu.Find<Menu>("tabMenu").Select("TabPresenter[History]"));
            var historyTab = PetShopWindow.Find<Tab>(FindBy.WpfText("History"));
            ThenWeShouldBeAbleToWaitFor((ignored, alsoIgnored) => historyTab.IsSelected());
        }
    }
}