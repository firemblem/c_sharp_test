using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Xml.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Workspace\github\c_sharp_test\source.json";
            KafkaResponse response = JsonConvert.DeserializeObject<KafkaResponse>(File.ReadAllText(path));
            Console.WriteLine(response);

            //foreach (var item in response!.dialogs)
            //{
            //    KafkaResponsePayload? payload = JsonConvert.DeserializeObject<KafkaResponsePayload>(item.payload);
            //    List<KafkaResponseDialogModel>? models = JsonConvert.DeserializeObject<List<KafkaResponseDialogModel>>(item.dialogModels);
            //    //Console.WriteLine(payload);
            //    //Console.WriteLine(models);


            //    string payloadString = JsonConvert.SerializeObject(payload, Formatting.Indented);
            //    string modelsString = JsonConvert.SerializeObject(models, Formatting.Indented);
            //    Console.WriteLine(payloadString);
            //    Console.WriteLine(modelsString);
            //}
        }
    }

    public class KafkaResponse
    {
        public String callStartTime;
        public String ani;
        public String callId;
        public String sessionId;
        public String botcode;
        public String callType;
        public String dnis;
        public String extension;
        public KafkaResponseWorkspaceInfo workspaceInfo;
        public String serviceCode;
        public String centerCode;
        public String calleeCode;
        public String campaignId;
        public String tenantId;
        public String outboundCallId;
        public List<KafkaResponseDialog> dialogs;
        public String callEndTime;
        public override string ToString()
        {
            string format = "{\n";
            //format += string.Format(@" "callStartTime" : "{0}" \n", callStartTime) ;
            format += "}";
            return format;
        }
    }

    public class KafkaResponseWorkspaceInfo
    {
        public String id;
        public String name;
    }

    public class KafkaResponseDialog
    {
        public String startTime;
        //public String event;
        public KafkaResponseStt stt;         // nullable
        public KafkaResponseTts ai;     // nullable
        public KafkaResponseTts tts;    // nullable
        public String duration;                    // nullable
        public String payload;                     // (last dialogModels payload) nullable
        public String dialogModels;                // nullable
        public String endTime;
    }

    public class KafkaResponseStt
    {
        public String data;
        public String duration;
        public String endTime;
        public String startTime;
    }

    public class KafkaResponseTts
    {
        public List<String> data;
        public String duration;
        public String endTime;
        public String startTime;
    }

    public class KafkaResponsePayload
    {
        public Boolean bargeIn;
        public int epdPauseLen;
        public int dtmfLength;
        public String terminationKey;
        public int noinputTimeout;
        public Boolean logMasked;
        public Boolean isWarning;
        public Boolean checkIn;
        public Boolean checkOut;
        public String customLog;
        public Boolean advancedSmartBargeIn;
        public KafkaResponseEngineConfig qccEngineConfig;
        public List<String> quickCommands;
        public KafkaResponseEngineConfig sttEngineConfig;
        public KafkaResponseEngineConfig ttsEngineConfig;
        public int maxSpeechTimeout;
        public int interdigitTimeout;
        public String receiver;
        public String channel;
        public String transferDestinationNumber;
        public String messageText;
    }

    public class KafkaResponseDialogModel
    {
        public String name;
        public String label;
        public String type;
        public List<KafkaResponseCondition> conditions;
        public List<String> responses;
        public KafkaResponsePayload payload;
        public Boolean enableScope;
        public Boolean endOfScope;
    }

    public class KafkaResponseEngineConfig
    {
        public String code;
        public KafkaResponseConfigurations configurations;
    }

    public class KafkaResponseCondition
    {
        //public String operator;
        public String variable;
        public String parsedVariable;
        public String value;
        public String parsedValue;
        public String comparison;
    }

    public class KafkaResponseConfigurations
    {
        public String host;
        public String port;
        public String uri;
        public String task;
        public String language;
        public String speaker;
        public String maxConnectionTimeout;
        public String maxReadTimeout;
        public String format;
        public String pitch;
        public String speed;
        public String volume;
    }
}