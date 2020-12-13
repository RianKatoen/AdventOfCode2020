using AdventOfCode2020.Traveling.Customs;
using System.Linq;
using Xunit;

namespace AdventOfCode2020.Traveling.Tests.Customs
{
    public class QuestionnaireHandlerTests
    {
        [Theory]
        [InlineData(QuestionnaireAnswer.a | QuestionnaireAnswer.b | QuestionnaireAnswer.c, 3)]
        [InlineData(QuestionnaireAnswer.a, 1)]
        [InlineData(QuestionnaireAnswer.a | QuestionnaireAnswer.c, 2)]
        [InlineData(QuestionnaireAnswer.None, 0)]
        [InlineData(QuestionnaireAnswer.All, 26)]
        public void Count_Should_Work(QuestionnaireAnswer questionnaireAnswers, int count)
        {
            var sut = new QuestionnaireHandler();
            Assert.Equal(count, sut.Count(questionnaireAnswers));
        }

        [Theory]
        [InlineData("abc", QuestionnaireAnswer.a | QuestionnaireAnswer.b | QuestionnaireAnswer.c)]
        [InlineData("a", QuestionnaireAnswer.a)]
        [InlineData("ac", QuestionnaireAnswer.a | QuestionnaireAnswer.c)]
        [InlineData("123", QuestionnaireAnswer.None)]
        public void HandlePerson_Should_Work(string answers, QuestionnaireAnswer expectedQuestionnaireAnswers)
        {
            var sut = new QuestionnaireHandler();
            var questionnaireAnswers = sut.HandlePerson(answers);
            Assert.Equal(expectedQuestionnaireAnswers, questionnaireAnswers);
        }

        [Fact]
        public void HandleData_EveryoneYes_Should_Work()
        {
            var data = new string[]
            {
                "abc",
                "",
                "a",
                "b",
                "c",
                null,
                "ab",
                "ac",
                null,
                "a",
                "a",
                "a",
                "a",
                null,
                "b"
            };

            var sut = new QuestionnaireHandler();
            var groupedAnswers = sut.HandleData(data, true).ToList();

            Assert.Equal(5, groupedAnswers.Count);

            Assert.Equal(QuestionnaireAnswer.a | QuestionnaireAnswer.b | QuestionnaireAnswer.c, groupedAnswers[0]);
            Assert.Equal(QuestionnaireAnswer.None, groupedAnswers[1]);
            Assert.Equal(QuestionnaireAnswer.a, groupedAnswers[2]);
            Assert.Equal(QuestionnaireAnswer.a, groupedAnswers[3]);
            Assert.Equal(QuestionnaireAnswer.b, groupedAnswers[4]);

            Assert.Equal(6, groupedAnswers.Select(a => sut.Count(a)).Sum());
        }

        [Fact]
        public void HandleData_AnyoneYes_Should_Work()
        {
            var data = new string[]
            {
                "abc",
                "",
                "a",
                "b",
                "c",
                null,
                "ab",
                "ac",
                null,
                "a",
                "a",
                "a",
                "a",
                null,
                "b"
            };

            var sut = new QuestionnaireHandler();
            var groupedAnswers = sut.HandleData(data).ToList();

            Assert.Equal(5, groupedAnswers.Count);

            Assert.Equal(QuestionnaireAnswer.a | QuestionnaireAnswer.b | QuestionnaireAnswer.c, groupedAnswers[0]);
            Assert.Equal(QuestionnaireAnswer.a | QuestionnaireAnswer.b | QuestionnaireAnswer.c, groupedAnswers[1]);
            Assert.Equal(QuestionnaireAnswer.a | QuestionnaireAnswer.b | QuestionnaireAnswer.c, groupedAnswers[2]);
            Assert.Equal(QuestionnaireAnswer.a, groupedAnswers[3]);
            Assert.Equal(QuestionnaireAnswer.b, groupedAnswers[4]);

            Assert.Equal(11, groupedAnswers.Select(a => sut.Count(a)).Sum());
        }
    }
}
