﻿namespace BattleNetPrefill.Integration.Test.DownloadTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [ExcludeFromCodeCoverage, Category("SkipCI")]
    public class Starcraft1
    {
        private ComparisonResult _results;

        [OneTimeSetUp]
        public async Task Setup()
        {
            // Run the download process only once
            var debugConfig = new DebugConfig { UseCdnDebugMode = true, CompareAgainstRealRequests = true };
            var tactProductHandler = new TactProductHandler(TactProduct.Starcraft1, new TestConsole(), debugConfig: debugConfig);
            _results = await tactProductHandler.ProcessProductAsync(forcePrefill: true);
        }

        [Test]
        public void Misses()
        {
            Assert.LessOrEqual(_results.MissCount, 0);
        }

        [Test]
        public void MissedBandwidth()
        {
            Assert.AreEqual(0, _results.MissedBandwidth.Bytes);
        }

        [Test]
        public void WastedBandwidth()
        {
            Assert.AreEqual(0, _results.WastedBandwidth.Bytes);
        }
    }
}
