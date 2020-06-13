using System;
using Dominio.Entidades.Contrato;

namespace Sicle.Web.Util
{
    public class ResourceMap
    {
        public static string CIRCLE_GRAY = "/img/circle_gray.png";
        public static string CIRCLE_RED = "/img/circle_red.png";
        public static string CIRCLE_YELLOW = "/img/circle_yellow.png";
        public static string CIRCLE_ORANGE = "/img/circle_orange.png";
        public static string CIRCLE_GREEN = "/img/circle_green.png";
        public static string DASH = "/img/dash.png";


        public static String GetContractIcon(ContractStatus status)
        {
            switch (status)
            {
                case ContractStatus.APPROVED:
                    return CIRCLE_GREEN;
                case ContractStatus.REJECTED:
                    return CIRCLE_RED;
                case ContractStatus.CREATED_IN_APPROVAL: 
                case ContractStatus.MODIFIED_IN_APPROVAL:
                    return CIRCLE_YELLOW;
                case ContractStatus.REMOVED:
                    return CIRCLE_RED;
                default:
                    return CIRCLE_GRAY;
            }
        }

        public static String GetEndorsementIcon(EndorsementStatus status)
        {
            switch (status)
            {
                case EndorsementStatus.ENDORSED:
                    return CIRCLE_GREEN;
                case EndorsementStatus.IN_ENDORSEMENT:
                    return CIRCLE_RED;
                case EndorsementStatus.NOT_NECESSARY:                    
                case EndorsementStatus.UNVALUED:
                    return CIRCLE_YELLOW;
                case EndorsementStatus.NONE:
                    return CIRCLE_RED;
                default:
                    return DASH;
            }
        }

        public static String GetMailIcon(MailStatus? status)
        {
            switch (status)
            {
                case MailStatus.SENT:
                    return CIRCLE_GREEN;
                case MailStatus.ERROR:
                    return CIRCLE_RED;
                case MailStatus.NOT_SENT: 
                    return CIRCLE_YELLOW;
                case MailStatus.NONE:                    
                default:
                    return DASH;
            }
        }

    }
}