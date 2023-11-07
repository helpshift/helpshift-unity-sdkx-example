using System;

namespace Helpshift
{
    /// <summary>
    /// Constants class for event names and their data keys
    /// </summary>
    public class HelpshiftEvent
    {
        public const string WIDGET_TOGGLE = "widgetToggle";
        public const string DATA_SDK_VISIBLE = "visible";

        public const string CONVERSATION_START = "conversationStart";
        public const string DATA_MESSAGE = "message";

        public const string MESSAGE_ADD = "messageAdd";
        public const string DATA_MESSAGE_TYPE = "type";
        public const string DATA_MESSAGE_BODY = "body";
        public const string DATA_MESSAGE_TYPE_ATTACHMENT = "attachment";
        public const string DATA_MESSAGE_TYPE_TEXT = "text";

        public const string CSAT_SUBMIT = "csatSubmit";
        public const string DATA_CSAT_RATING = "rating";
        public const string DATA_ADDITIONAL_FEEDBACK = "additionalFeedback";

        public const string CONVERSATION_STATUS = "conversationStatus";
        public const string DATA_LATEST_ISSUE_ID = "latestIssueId";
        public const string DATA_LATEST_ISSUE_PUBLISH_ID = "latestIssuePublishId";
        public const string DATA_IS_ISSUE_OPEN = "open";

        public const string CONVERSATION_END = "conversationEnd";

        public const string CONVERSATION_REJECTED = "conversationRejected";

        public const string CONVERSATION_RESOLVED = "conversationResolved";

        public const string CONVERSATION_REOPENED = "conversationReopened";


        public const string SDK_SESSION_STARTED = "helpshiftSessionStarted";

        public const string SDK_SESSION_ENDED = "helpshiftSessionEnded";

        public const string RECEIVED_UNREAD_MESSAGE_COUNT = "receivedUnreadMessageCount";
        public const string DATA_MESSAGE_COUNT = "count";
        public const string DATA_MESSAGE_COUNT_FROM_CACHE = "fromCache";

        public const string ACTION_CLICKED = "userClickOnAction";
        public const string DATA_ACTION = "actionType";
        public const string DATA_ACTION_TYPE = "actionData";
        public const string DATA_ACTION_TYPE_CALL = "call";
        public const string DATA_ACTION_TYPE_LINK = "link";

        public const string AGENT_MESSAGE_RECEIVED = "agentMessageReceived";
        public const string DATA_PUBLISH_ID = "publishId";
        public const string DATA_CREATED_TIME = "createdTs";
        public const string DATA_ATTACHMENTS = "attachments";
        public const string DATA_URL = "url";
        public const string DATA_CONTENT_TYPE = "contentType";
        public const string DATA_FILE_NAME = "fileName";
        public const string DATA_SIZE = "size";
        public const string DATA_MESSAGE_TYPE_APP_REVIEW_REQUEST = "app_review_request";
        public const string DATA_MESSAGE_TYPE_SCREENSHOT_REQUEST = "screenshot_request";
    }
}
