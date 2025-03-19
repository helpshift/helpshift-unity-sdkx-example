using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
#if UNITY_IOS || UNITY_ANDROID
using Helpshift;
#endif

namespace HelpshiftExample
{
    public class HelpshiftIdentityLoginScript : MonoBehaviour
    {
#if UNITY_IOS || UNITY_ANDROID

        private HelpshiftSdk _helpshiftX;
        private HelpshiftUserLoginEventListener _userLoginEventListener;
        Dictionary<string, object> loginConfig = new Dictionary<string, object>();
        Dictionary<string, object> appAttributes = new Dictionary<string, object>();
        Dictionary<string, string> appAttributesCUF = new Dictionary<string, string>();

        Dictionary<string, object> masterAttributes = new Dictionary<string, object>();
        Dictionary<string, string> masterAttributesCUF = new Dictionary<string, string>();

        void Awake()
        {
            _helpshiftX = HelpshiftSdk.GetInstance();
            _userLoginEventListener = new HelpshiftUserLoginEventListener();
        }

        public void LoginIdentityUser()
        {
#if UNITY_ANDROID || UNITY_IOS
            string loginJWT = getDataFromInputField("identityJWT");
            _helpshiftX.LoginWithIdentity(loginJWT,loginConfig, _userLoginEventListener);
            Debug.Log("Helpshift - Login Identity User called");
#endif
        }

        public void AddUserIdentities()
        {
#if UNITY_ANDROID || UNITY_IOS
            string identitiesJwt = getDataFromInputField("identityJWT");
            _helpshiftX.AddUserIdentities(identitiesJwt);
            Debug.Log("Helpshift - Add User Identity called");
#endif
        }

        public void LoginAnonIdentityUser()
        {
#if UNITY_ANDROID || UNITY_IOS
            _helpshiftX.LoginWithIdentity("",loginConfig, _userLoginEventListener);
            Debug.Log("Helpshift - Login Anon Identity User called");
#endif
        }

        public void AddLoginConfig() {
            #if UNITY_ANDROID || UNITY_IOS
                string loginConfigKey = getDataFromInputField("loginConfigKey");
                string loginConfigValue = getDataFromInputField("loginConfigValue");
                loginConfig.Add(loginConfigKey, loginConfigValue);

                setDataInInputField("loginConfigKey", "");
                setDataInInputField("loginConfigValue", "");
                Debug.Log("Helpshift - AddLoginConfig called");

            #endif
        }

        public void AddAppAttributesConfig() {
            #if UNITY_ANDROID || UNITY_IOS

                string appAttributeKey = getDataFromInputField("appAttributeKey");
                string appAttributeValue = getDataFromInputField("appAttributeValue");

                setDataInInputField("appAttributeKey", "");
                setDataInInputField("appAttributeValue", "");

                if (appAttributeValue.Contains(",")) {
                    appAttributes.Add(appAttributeKey, appAttributeValue.Split(','));
                } else {
                    appAttributes.Add(appAttributeKey, appAttributeValue);
                }
                Debug.Log("Helpshift - AddAppAttributesConfig called");

            #endif
        }

        public void AddMasterAttributesConfig() {
            #if UNITY_ANDROID || UNITY_IOS
                string masterAttributeKey = getDataFromInputField("masterAttributeKey");
                string masterAttributeValue = getDataFromInputField("masterAttributeValue");

                setDataInInputField("masterAttributeKey", "");
                setDataInInputField("masterAttributeValue", "");

                if (masterAttributeValue.Contains(",")) {
                    masterAttributes.Add(masterAttributeKey, masterAttributeValue.Split(','));
                } else {
                    masterAttributes.Add(masterAttributeKey, masterAttributeValue);
                }
                Debug.Log("Helpshift - AddMasterAttributesConfig called");
            #endif
        }

        public void AddAppAttributesCUF() {
            #if UNITY_ANDROID || UNITY_IOS
                string appAttributesCUFKey = getDataFromInputField("appAttributesCUFKey");
                string appAttributesCUFValue = getDataFromInputField("appAttributesCUFValue");

                appAttributesCUF.Add(appAttributesCUFKey, appAttributesCUFValue);

                setDataInInputField("appAttributesCUFKey", "");
                setDataInInputField("appAttributesCUFValue", "");


            #endif
        }

        public void AddMasterAttributesCUF() {
            #if UNITY_ANDROID || UNITY_IOS
                string masterAttributesCUFKey = getDataFromInputField("masterAttributesCUFKey");
                string masterAttributesCUFValue = getDataFromInputField("masterAttributesCUFValue");
                masterAttributesCUF.Add(masterAttributesCUFKey, masterAttributesCUFValue);

                setDataInInputField("masterAttributesCUFKey", "");
                setDataInInputField("masterAttributesCUFValue", "");

                Debug.Log("Helpshift - AddMasterAttributesCUF called");

            #endif
        }

        public void UpdateAppAttributes()
        {
#if UNITY_ANDROID || UNITY_IOS
            if (appAttributesCUF.Count > 0) {
                appAttributes["custom_user_fields"] = appAttributesCUF;
            }
            _helpshiftX.UpdateAppAttributes(appAttributes);
            Debug.Log("Helpshift - UpdateAppAttributes called");
#endif
        }

        public void ClearData(){
            appAttributes.Clear();
            masterAttributes.Clear();

            masterAttributesCUF.Clear();
            appAttributesCUF.Clear();

            loginConfig.Clear();

            setDataInInputField("appAttributeKey", "");
            setDataInInputField("appAttributeValue", "");

            setDataInInputField("masterAttributeKey", "");
            setDataInInputField("masterAttributeValue", "");

            setDataInInputField("masterAttributesCUFKey", "");
            setDataInInputField("masterAttributesCUFValue", "");

            setDataInInputField("appAttributesCUFKey", "");
            setDataInInputField("appAttributesCUFValue", "");

        }

        public void UpdateMasterAttributes()
        {
#if UNITY_ANDROID || UNITY_IOS
            Debug.Log("Helpshift - UpdateMasterAttributes called");
            if (masterAttributesCUF.Count > 0) {
                masterAttributes["custom_user_fields"] = masterAttributesCUF;
            }
            _helpshiftX.UpdateMasterAttributes(masterAttributes);
#endif
        }

        public void CloseIdentityScene() {
            SceneManager.UnloadSceneAsync("HelpshiftIdentityLogin");
        }

        public void openEventLogger() {
            SceneManager.LoadScene("HelpshiftEventLogger",LoadSceneMode.Additive);
        }

        private string getDataFromInputField(string fieldName)
        {
            InputField field = GameObject.Find(fieldName).GetComponent<InputField>();

            if (field == null) {
                Debug.LogError($"GameObject with name '{fieldName}' not found.");
            }
            return String.IsNullOrEmpty(field.text) ? "" : field.text;
        }

        private void setDataInInputField(string fieldName, string value)
        {
            InputField field = GameObject.Find(fieldName).GetComponent<InputField>();
            field.text = value;
        }
#endif
    }

}