using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfomanceTest
{
    class Queries
    {
        public static readonly string[] ColumnNames = {
            "Question_Id_No_Answer"
            ,"TextBlock_Id"
            ,"Survey_Id_Congratulation"
            ,"Survey_Id_Footer"
            ,"Survey_Id_Header"
            ,"Variable_Id"
            ,"VariableCharacteristic_Id"
            ,"MatrixRow_Autocomplete_Id"
            ,"MatrixColumn_Autocomplete_Id"
            ,"MatrixQuestionColumn_Id"
            ,"MatrixColumnGroup_DropDownPrompt_Id"
            ,"MatrixColumnGroup_Id_No_Answer"
            ,"MatrixColumnGroup_Title_Id"
            ,"RowRightLabel_Id"
            ,"MatrixQuestionRow_Id"
            ,"MultipleChoiceQuestionChoice_Autocomplete_Id"
            ,"MultipleChoiceQuestionChoice_Id"
            ,"RankOrderQuestionChoice_Autocomplete_Id"
            ,"RankOrderQuestionChoice_Id"
            ,"SingleChoiceQuestionChoice_Autocomplete_Id"
            ,"SingleChoiceQuestionChoice_Id"
            ,"CustomForward_Id"
            ,"Question_Id_Question"
            ,"Question_Id_Hint"
            ,"DropDownQuestionChoice_Autocomplete_Id"
            ,"DropDownQuestionChoice_Id"
            ,"DropDownQuestion_Id"
            ,"OpenQuestion_Id"
            ,"SliderQuestionChoice_Autocomplete_Id"
            ,"SliderQuestionChoice_Id"
            ,"Content_MessageTemplate_Id"
            ,"Subject_MessageTemplate_Id"
            ,"SendEmail_Id_Message"
            ,"SendEmail_Id_Subject"
            ,"ValueAssignment_Id"
            ,"ImplicitAssociationQuestionStimulus_Autocomplete_Id"
            ,"ImplicitAssociationQuestionStimulus_Id"
            ,"ImplicitAssociationQuestionId_DislikeButton"
            ,"ImplicitAssociationQuestionId_LikeButton"
            ,"OpenQuestion_Id_Placeholder"
        };

        public const string GetDupItem = @"
SELECT st.{0}
 ,st.Locale
 ,COUNT(*)
FROM SurveyText st
WHERE st.{0} IS NOT NULL
GROUP BY st.{0}
        ,st.Locale";
    }
}
