﻿// -------------------------------------------------------------------------------------------------
// <copyright file="AttributeValueEnumerationTestFixture.cs" company="RHEA System S.A.">
//
//   Copyright 2017 RHEA System S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace ReqIFLib.Tests
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;

    using NUnit.Framework;
    using ReqIFSharp;

    /// <summary>
    /// Suite of tests for the <see cref="AttributeValueEnumeration"/>
    /// </summary>
    [TestFixture]
    public class AttributeValueEnumerationTestFixture
    {
        [Test]
        public void VerifyThatTheAttributeDefinitionCanBeSetOrGet()
        {
            var attributeDefinitionEnumeration = new AttributeDefinitionEnumeration();

            var attributeValueEnumeration = new AttributeValueEnumeration();
            attributeValueEnumeration.Definition = attributeDefinitionEnumeration;

            var attributeValue = (AttributeValue)attributeValueEnumeration;

            Assert.AreEqual(attributeDefinitionEnumeration, attributeValue.AttributeDefinition);

            attributeValue.AttributeDefinition = attributeDefinitionEnumeration;

            Assert.AreEqual(attributeDefinitionEnumeration, attributeValue.AttributeDefinition);
        }

        [Test]
        public void VerifytThatExceptionIsRaisedWhenInvalidAttributeDefinitionIsSet()
        {
            var attributeDefinitionString = new AttributeDefinitionString();
            var attributeValueEnumeration = new AttributeValueEnumeration();
            var attributeValue = (AttributeValue)attributeValueEnumeration;

            Assert.Throws<ArgumentException>(() => attributeValue.AttributeDefinition = attributeDefinitionString);
        }

        [Test]
        public void VerifyThatWriteXmlWithoutDefinitionSetThrowsSerializationException()
        {
            using (var fs = new FileStream("test.xml", FileMode.Create))
            {
                using (var writer = XmlWriter.Create(fs, new XmlWriterSettings { Indent = true }))
                {
                    var attributeValueEnumeration = new AttributeValueEnumeration();
                    Assert.Throws<SerializationException>(() => attributeValueEnumeration.WriteXml(writer));
                }
            }
        }
    }
}
