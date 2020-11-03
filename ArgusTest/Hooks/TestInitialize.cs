using TechTalk.SpecFlow;

namespace ArgusTest.Hooks.Settings.test
{
	[Binding]
    public class TestInitialize
    {

        private Settings _settings;
        public TestInitialize(Settings settings)
        {
            _settings = settings;
        }

       

    }
}