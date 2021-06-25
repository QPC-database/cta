﻿using CTA.WebForms2Blazor.ClassConverters;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace CTA.WebForms2Blazor.Tests.ClassConverters
{
    public class ControlCodeBehindClassConverterTests
    {
        private static string InputRelativePath => Path.Combine(ClassConverterSetupFixture.TestProjectNestedDirectoryName, "CodeBehind.ascx.cs");
        private static string ExpectedOutputPath => Path.Combine("Components", ClassConverterSetupFixture.TestProjectNestedDirectoryName, "CodeBehind.razor");

        private ControlCodeBehindClassConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new ControlCodeBehindClassConverter(InputRelativePath,
                ClassConverterSetupFixture.TestProjectDirectoryPath,
                ClassConverterSetupFixture.TestSemanticModel,
                ClassConverterSetupFixture.TestClassDec,
                ClassConverterSetupFixture.TestTypeSymbol);
        }

        [Test]
        public async Task MigrateClassAsync_Maps_New_Relative_Path_To_Correct_Location()
        {
            var fileInfo = await _converter.MigrateClassAsync();

            Assert.AreEqual(ExpectedOutputPath, fileInfo.RelativePath);
        }
    }
}