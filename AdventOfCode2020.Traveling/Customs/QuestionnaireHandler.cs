using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Traveling.Customs
{
    public class QuestionnaireHandler
    {
        public int Count(QuestionnaireAnswer questionnaireAnswer)
        {
            uint value = (uint)questionnaireAnswer;
            int count = 0;
            while (value != 0)
            {
                count++;
                value &= value - 1;
            }

            return count;
        }

        public QuestionnaireAnswer HandlePerson(string answers)
        {
            var questionnaireAnswer = QuestionnaireAnswer.None;
            foreach (var answer in answers)
            {
                if (char.IsLower(answer) && Enum.TryParse<QuestionnaireAnswer>(answer.ToString(), false, out var enumAnswer))
                {
                    questionnaireAnswer |= enumAnswer;
                }
            }

            return questionnaireAnswer;
        }

        public QuestionnaireAnswer HandleGroup(IEnumerable<string> answersFromGroup, bool everyoneYes = false)
        {
            QuestionnaireAnswer questionnaireAnswer;
            if (everyoneYes)
            {
                if (answersFromGroup.Any())
                {
                    questionnaireAnswer = QuestionnaireAnswer.All;
                    foreach (var answers in answersFromGroup)
                        questionnaireAnswer &= HandlePerson(answers);
                }
                else
                {
                    questionnaireAnswer = QuestionnaireAnswer.None;
                }
            }
            else
            {
                questionnaireAnswer = QuestionnaireAnswer.None;
                foreach (var answers in answersFromGroup)
                    questionnaireAnswer |= HandlePerson(answers);
            }

            return questionnaireAnswer;
        }

        public IEnumerable<QuestionnaireAnswer> HandleData(IEnumerable<string> allAnswers, bool everyoneYes = false)
        {
            var group = new List<string>();
            foreach (var line in allAnswers)
            {
                if (string.IsNullOrEmpty(line))
                {
                    yield return HandleGroup(group, everyoneYes);
                    group = new List<string>();
                }
                else
                {
                    group.Add(line.Trim());
                }
            }

            yield return HandleGroup(group, everyoneYes);
        }
    }
}
