using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
#if UNITY_IOS || UNITY_ANDROID
using Helpshift;
#endif

namespace HelpshiftExample
{
    public class HelpshiftExampleScript : MonoBehaviour
    {
#if UNITY_IOS || UNITY_ANDROID

        private HelpshiftSdk _helpshiftX;
        Dictionary<string, object> cifDictionary = new Dictionary<string, object>();
        Dictionary<string, object> genericConfigDictionary = new Dictionary<string, object>();

        void Awake()
        {
            Debug.Log("Unity - Awake called");

            _helpshiftX = HelpshiftSdk.GetInstance();
            string domainName = "gayatri.helpshift.com";

            string appId;
#if UNITY_ANDROID
            appId = "gayatri_platform_20181018063833353-6d863ba814cb367";
#elif UNITY_IOS
            appId = "<your-app-ios-app-id>";
#endif

            _helpshiftX.Install(appId, domainName, GetInstallConfig());
            _helpshiftX.SetHelpshiftEventsListener(new HSEventsListener());
            _helpshiftX.SetHelpshiftProactiveConfigCollector(new ProactiveConfigCollector());
#if UNITY_ANDROID
            FirebaseIntegration.initFirebase();
#endif
        }

        public void ShowConversation()
        {
#if UNITY_ANDROID || UNITY_IOS
            _helpshiftX.ShowConversation(GetConversationConfig());
            Debug.Log("Helpshift - ShowConversation called");
#endif
        }

        public void ShowFAQs()
        {
#if UNITY_ANDROID || UNITY_IOS
            _helpshiftX.ShowFAQs(GetConversationConfig());
            Debug.Log("Helpshift - ShowFAQs called");
#endif
        }

        public void ShowFAQSection()
        {
#if UNITY_ANDROID || UNITY_IOS
            string faqSectionId = getDataFromInputField("faq_section_id");
            _helpshiftX.ShowFAQSection(faqSectionId, GetConversationConfig());
            Debug.Log("Helpshift - ShowFAQSection called");
#endif
        }

        public void ShowSingleFAQ()
        {
#if UNITY_ANDROID || UNITY_IOS
            string faqId = getDataFromInputField("faq_id");
            _helpshiftX.ShowSingleFAQ(faqId, GetConversationConfig());
            Debug.Log("Helpshift - ShowSingleFAQ called");
#endif
        }

 public void AddUserTrail()
        {
#if UNITY_ANDROID || UNITY_IOS
            string userTrail = getDataFromInputField("usertrail_input");
            _helpshiftX.AddUserTrail(userTrail);
        
#endif
        }

        public void AddDebugLog()
        {
#if UNITY_ANDROID || UNITY_IOS
            string tag = getDataFromInputField("log_tag");
            string message = getDataFromInputField("log_message");
            string level = getDataFromDropDownField("log_dropdown");
            Debug.Log("Helpshift - Calling debug log: Level: " + level + ", tag " + tag + ", message: " + message);
            switch(level)
            {
                case "Verbose": HelpshiftLog.v(tag, message); break;
                case "Debug": HelpshiftLog.d(tag, message); break;
                case "Info": HelpshiftLog.i(tag, message); break;
                case "Warn": HelpshiftLog.w(tag, message); break;
                case "Error": HelpshiftLog.e(tag, message); break;
            }
#endif
        }

        public void SetSDKLanguage()
        {
#if UNITY_ANDROID || UNITY_IOS
            string langCode = getDataFromInputField("language_input");
            _helpshiftX.SetSDKLanguage(langCode);
#endif
        }

        public void LeaveBreadCrumb()
        {
#if UNITY_ANDROID || UNITY_IOS
            string crumb = getDataFromInputField("breadcrumb_input");
            _helpshiftX.LeaveBreadcrumb(crumb);
#endif
        }

        public void ClearBreadCrumb()
        {
#if UNITY_ANDROID || UNITY_IOS
            _helpshiftX.ClearBreadcrumbs();
#endif
        }

        public void ClearAnonUser()
        {
#if UNITY_ANDROID || UNITY_IOS          
           _helpshiftX.ClearAnonymousUserOnLogin(getFlagFromToggleField("clear_anon_flag"));            
#endif
        }

        public void RequestUnreadCount()
        {
#if UNITY_ANDROID || UNITY_IOS
            _helpshiftX.RequestUnreadMessageCount(getFlagFromToggleField("from_remote"));
            Debug.Log("Helpshift - RequestUnreadCount called");
#endif
        }


        public void Login()
        {
#if UNITY_ANDROID || UNITY_IOS
            try
            {
                Boolean isLoggedIn = _helpshiftX.Login(GetUserDetails());
                Debug.Log("Helpshift - Login called isLoggedIn :" + isLoggedIn);
            } catch (Exception e)
            {

                Debug.Log("Error in Helpshift - Login." + e.Message);
            }
#endif

        }

        public void Logout()
        {
#if UNITY_ANDROID || UNITY_IOS
            _helpshiftX.Logout();
            Debug.Log("Helpshift - Logout called");
#endif
        }

        public void GetPluginVersion()
        {
#if UNITY_ANDROID || UNITY_IOS
            string version = _helpshiftX.SdkVersion();
            Debug.Log("Helpshift - SDK Version is :" + version);
#endif
        }

        public void CloseHelpshift()
        {
#if UNITY_ANDROID || UNITY_IOS
            Invoke("CloseSession", 8);
#endif
        }

        void CloseSession()
        {
            _helpshiftX.CloseSession();
            Debug.Log("Helpshift - Closesession");
        }

        public void AddCIF()
        {
#if UNITY_ANDROID || UNITY_IOS
            Debug.Log("Helpshift - Add CIF called");
            Dictionary<string, string> cif = new Dictionary<string, string>();
            string cifType = getDataFromDropDownField("cif_type");
            string cifValue = getDataFromInputField("cif_value");

            cif.Add("type", cifType);
            cif.Add("value", cifValue);

            string cifName = getDataFromInputField("cif_name");

            if (!String.IsNullOrEmpty(cifType) && !String.IsNullOrEmpty(cifName))
            {
                cifDictionary.Add(cifName, cif);
            } else
            {
                Debug.Log("Error adding CIF, invalid type or name");
            }

            setDataInInputField("cif_name", "");
            setDataInInputField("cif_value", "");
#endif
        }

        public void AddGenericConfig() {
#if UNITY_ANDROID || UNITY_IOS
            Debug.Log("Helpshift - Add generic config called");

            string key = getDataFromInputField("configKey");
            string value = getDataFromInputField("configValue");

            if (string.IsNullOrEmpty(key)) {
                Debug.Log("Error adding config, invalid key!");
                return;
            }

            Boolean valueBool = false;
            long valueLong = 0L;

            if (Boolean.TryParse(value, out valueBool)) {
                genericConfigDictionary[key] = valueBool;
            } else if (long.TryParse(value, out valueLong)) {
                genericConfigDictionary[key] = valueLong;
            } else {
                genericConfigDictionary[key] = value;
            }

            setDataInInputField("configKey", "");
            setDataInInputField("configValue", "");
#endif
        }

        public void ClearConfig() {
#if UNITY_ANDROID || UNITY_IOS
            genericConfigDictionary.Clear();
            cifDictionary.Clear();

            setFlagInToggleField("full_privacy", false);
            setDataInInputField("comma_separate", "");
            setDataInInputField("configKey", "");
            setDataInInputField("configValue", "");

#endif
        }


        private Dictionary<string, string> GetUserDetails()
        {
            string userId = getDataFromInputField("user_id");
            string userName = getDataFromInputField("user_name");
            string userEmail = getDataFromInputField("user_email");
            string userAuthToken = getDataFromInputField("user_auth_token");

            Dictionary<string, string> userDetails = new Dictionary<string, string>();

            if (String.IsNullOrEmpty(userId) && String.IsNullOrEmpty(userEmail))
            {
                throw new Exception("Invalid User data.");
            }

            if (!String.IsNullOrEmpty(userId)) userDetails["userId"] = userId;
            if (!String.IsNullOrEmpty(userEmail)) userDetails["userEmail"] = userEmail;
            if (!String.IsNullOrEmpty(userName)) userDetails["userName"] = userName;
            if (!String.IsNullOrEmpty(userAuthToken)) userDetails["userAuthToken"] = userAuthToken;

            return userDetails;
        }

        private Dictionary<string, object> GetConversationConfig()
        {
            string tags = getDataFromInputField("comma_separate");
            string[] tagsArray = tags.Split(',');

            bool fullPrivacy = getFlagFromToggleField("full_privacy");
            string contactUsValue = getDataFromDropDownField("enable_contactus_dropdown");

            Dictionary<string, object> config = new Dictionary<string, object>();

            if (cifDictionary.Count > 0) {
                config["cifs"] = cifDictionary;
            }

            if (tagsArray.Length > 0) {
                config["tags"] = tagsArray;
            }

            config["fullPrivacy"] = fullPrivacy;
            config["enableContactUs"] = contactUsValue;

            foreach (var pair in genericConfigDictionary) {
                config[pair.Key] = pair.Value;
            }

            return config;
        }


        public static Dictionary<string, object> GetCifs()
        {
            Dictionary<string, object> joiningDate = new Dictionary<string, object>();
            joiningDate.Add("type", "date");
            joiningDate.Add("value", 1505927361535L);

            Dictionary<string, string> stockLevel = new Dictionary<string, string>();
            stockLevel.Add("type", "number");
            stockLevel.Add("value", "1505");

            Dictionary<string, string> employeeName = new Dictionary<string, string>();
            employeeName.Add("type", "singleline");
            employeeName.Add("value", "Bugs helpshift");

            Dictionary<string, string> isPro = new Dictionary<string, string>();
            isPro.Add("type", "checkbox");
            isPro.Add("value", "true");

            Dictionary<string, object> cifDictionary = new Dictionary<string, object>();
            cifDictionary.Add("joining_date", joiningDate);
            cifDictionary.Add("stock_level", stockLevel);
            cifDictionary.Add("employee_name", employeeName);
            cifDictionary.Add("is_pro", isPro);
            return cifDictionary;
        }

        private Dictionary<string, object> GetInstallConfig()
        {

            Dictionary<string, object> installDictionary = new Dictionary<string, object>();
            installDictionary.Add(HelpshiftSdk.ENABLE_LOGGING, true);
#if UNITY_ANDROID
            
            installDictionary.Add(HelpshiftSdk.NOTIFICATION_SOUND_ID, "custom_notification");
            installDictionary.Add(HelpshiftSdk.NOTIFICATION_ICON,"notification_icon");
            //installDictionary.Add(HelpshiftSdk.NOTIFICATION_CHANNEL_ID, "Example_HS_Support");
            installDictionary.Add(HelpshiftSdk.NOTIFICATION_LARGE_ICON, "notification_icon");
            
#endif
            return installDictionary;
        }

        private string getDataFromInputField(string fieldName)
        {
            InputField field = GameObject.Find(fieldName).GetComponent<InputField>();
            return String.IsNullOrEmpty(field.text) ? "" : field.text;
        }

        private void setDataInInputField(string fieldName, string value)
        {
            InputField field = GameObject.Find(fieldName).GetComponent<InputField>();
            field.text = value;
        }

        private bool getFlagFromToggleField(string fieldName)
        {
            Toggle field = GameObject.Find(fieldName).GetComponent<Toggle>();
            return field.isOn;
        }

        private void setFlagInToggleField(string fieldName, bool value)
        {
            Toggle field = GameObject.Find(fieldName).GetComponent<Toggle>();
            field.isOn = value;
        }

        private string getDataFromDropDownField(string fieldName)
        {
            Dropdown field = GameObject.Find(fieldName).GetComponent<Dropdown>();
            return field.options[field.value].text;
        }
#endif
    }
}