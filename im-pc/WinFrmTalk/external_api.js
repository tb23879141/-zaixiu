!function(e,t){"object"==typeof exports&&"object"==typeof module?module.exports=t():"function"==typeof define&&define.amd?define([],t):"object"==typeof exports?exports.JitsiMeetExternalAPI=t():e.JitsiMeetExternalAPI=t()}("undefined"!=typeof self?self:this,function(){return function(e){function t(r){if(n[r])return n[r].exports;var i=n[r]={i:r,l:!1,exports:{}};return e[r].call(i.exports,i,i.exports,t),i.l=!0,i.exports}var n={};return t.m=e,t.c=n,t.d=function(e,n,r){t.o(e,n)||Object.defineProperty(e,n,{configurable:!1,enumerable:!0,get:r})},t.n=function(e){var n=e&&e.__esModule?function(){return e.default}:function(){return e};return t.d(n,"a",n),n},t.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},t.p="/libs/",t(t.s=3)}([function(e,t,n){var r=n(2),i=n(6),s={},a=[],o=r.levels.TRACE;e.exports={addGlobalTransport:function(e){r.addGlobalTransport(e)},removeGlobalTransport:function(e){r.removeGlobalTransport(e)},getLogger:function(e,t,n){var i=new r(o,e,t,n);return e?(s[e]=s[e]||[],s[e].push(i)):a.push(i),i},setLogLevelById:function(e,t){for(var n=t?s[t]||[]:a,r=0;r<n.length;r++)n[r].setLevel(e)},setLogLevel:function(e){o=e;for(var t=0;t<a.length;t++)a[t].setLevel(e);for(var n in s){var r=s[n]||[];for(t=0;t<r.length;t++)r[t].setLevel(e)}},levels:r.levels,LogCollector:i}},function(e,t,n){"use strict";(function(e){function r(e){var t=new RegExp("^"+f+"+","gi"),n=t.exec(e);if(n){var r=n[n.length-1].toLowerCase();"http:"!==r&&"https:"!==r&&(r="https:"),(e=e.substring(t.lastIndex)).startsWith("//")&&(e=r+e)}return e}function i(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{},t=[];for(var n in e)try{t.push(n+"="+encodeURIComponent(JSON.stringify(e[n])))}catch(e){l.warn("Error encoding "+n+": "+e)}return t}function s(e){var t={toString:a},n=void 0,r=void 0;if(e=e.replace(/\s/g,""),(r=(n=new RegExp("^"+f,"gi")).exec(e))&&(t.protocol=r[1].toLowerCase(),e=e.substring(n.lastIndex)),r=(n=new RegExp("^"+c,"gi")).exec(e)){var i=r[1].substring(2);e=e.substring(n.lastIndex);var s=i.indexOf("@");-1!==s&&(i=i.substring(s+1)),t.host=i;var o=i.lastIndexOf(":");-1!==o&&(t.port=i.substring(o+1),i=i.substring(0,o)),t.hostname=i}var l=void 0;if((r=(n=new RegExp("^"+h,"gi")).exec(e))&&(l=r[1],e=e.substring(n.lastIndex)),l?l.startsWith("/")||(l="/"+l):l="/",t.pathname=l,e.startsWith("?")){var u=e.indexOf("#",1);-1===u&&(u=e.length),t.search=e.substring(0,u),e=e.substring(u)}else t.search="";return t.hash=e.startsWith("#")?e:"",t}function a(e){var t=e||this,n=t.hash,r=t.host,i=t.pathname,s=t.protocol,a=t.search,o="";return s&&(o+=s),r&&(o+="//"+r),o+=i||"/",a&&(o+=a),n&&(o+=n),o}function o(e){var t=s(r(e.url||""));if(!t.protocol){var n=e.protocol||e.scheme;n&&(n.endsWith(":")||(n+=":"),t.protocol=n)}var a=t.pathname;if(!t.host){var o=e.domain||e.host||e.hostname;if(o){var l=s(r(u+"//"+o)),c=l.host,h=l.hostname,f=l.pathname,d=l.port;c&&(t.host=c,t.hostname=h,t.port=d),"/"===a&&"/"!==f&&(a=f)}}var p=e.roomName||e.room;!p||!t.pathname.endsWith("/")&&t.pathname.endsWith("/"+p)||(a.endsWith("/")||(a+="/"),a+=p),t.pathname=a;var v=e.jwt;if(v){var g=t.search;-1===g.indexOf("?jwt=")&&-1===g.indexOf("&jwt=")&&(g.startsWith("?")||(g="?"+g),1===g.length||(g+="&"),g+="jwt="+v,t.search=g)}for(var m=t.hash,y=["config","interfaceConfig"],_=0;_<y.length;_++){var b=y[_],w=i(e[b+"Overwrite"]||e[b]||e[b+"Override"]);if(w.length){var L=b+"."+w.join("&"+b+".");m.length?L="&"+L:m="#",m+=L}}return t.hash=m,t.toString()||void 0}t.a=o,"function"==typeof Symbol&&Symbol.iterator;var l=n(0).getLogger(e),u="org.jitsi.meet:",c="(//[^/?#]+)",h="([^?#]*)",f="([a-z][a-z0-9\\.\\+-]*:)"}).call(t,"react/features/base/util/uri.js")},function(e,t){function n(){var e=arguments[0],t=arguments[1],n=Array.prototype.slice.call(arguments,2);if(!(i[t]<e.level))for(var r=function(){var e={methodName:"",fileLocation:"",line:null,column:null},t=new Error,n=t.stack?t.stack.split("\n"):[];if(!n||n.length<1)return e;var r=null;return n[3]&&(r=n[3].match(/\s*at\s*(.+?)\s*\((\S*)\s*:(\d*)\s*:(\d*)\)/)),!r||r.length<=4?(0===n[2].indexOf("log@")?e.methodName=n[3].substr(0,n[3].indexOf("@")):e.methodName=n[2].substr(0,n[2].indexOf("@")),e):(e.methodName=r[1],e.fileLocation=r[2],e.line=r[3],e.column=r[4],e)}(),a=s.concat(e.transports),o=0;o<a.length;o++){var l=a[o],u=l[t];u&&"function"==typeof u&&u.bind(l,e.id?"["+e.id+"]":"","<"+r.methodName+">: ").apply(l,n)}}function r(e,t,r,s){this.id=t,this.format=s,this.transports=r,this.transports||(this.transports=[]),this.level=i[e];for(var a=Object.keys(i),o=0;o<a.length;o++)this[a[o]]=n.bind(null,this,a[o])}var i={trace:0,debug:1,info:2,log:3,warn:4,error:5};r.consoleTransport=console;var s=[r.consoleTransport];r.addGlobalTransport=function(e){-1===s.indexOf(e)&&s.push(e)},r.removeGlobalTransport=function(e){var t=s.indexOf(e);-1!==t&&s.splice(t,1)},r.prototype.setLevel=function(e){this.level=i[e]},e.exports=r,r.levels={TRACE:"trace",DEBUG:"debug",INFO:"info",LOG:"log",WARN:"warn",ERROR:"error"}},function(e,t,n){e.exports=n(4).default},function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),function(e){function r(e,t){e._numberOfParticipants+=t}function i(e){var t=void 0;return"string"==typeof e&&null!==String(e).match(/([0-9]*\.?[0-9]+)(em|pt|px|%)$/)?t=e:"number"==typeof e&&(t=e+"px"),t}var s=n(5),a=n.n(s),o=n(1),l=n(7),u=n(11),c=n.n(u),h=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),f=function(){return function(e,t){if(Array.isArray(e))return e;if(Symbol.iterator in Object(e))return function(e,t){var n=[],r=!0,i=!1,s=void 0;try{for(var a,o=e[Symbol.iterator]();!(r=(a=o.next()).done)&&(n.push(a.value),!t||n.length!==t);r=!0);}catch(e){i=!0,s=e}finally{try{!r&&o.return&&o.return()}finally{if(i)throw s}}return n}(e,t);throw new TypeError("Invalid attempt to destructure non-iterable instance")}}(),d="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(e){return typeof e}:function(e){return e&&"function"==typeof Symbol&&e.constructor===Symbol&&e!==Symbol.prototype?"symbol":typeof e},p=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},v=n(0).getLogger(e),g=["css/all.css","libs/alwaysontop.min.js"],m={avatarUrl:"avatar-url",displayName:"display-name",email:"email",hangup:"video-hangup",submitFeedback:"submit-feedback",toggleAudio:"toggle-audio",toggleChat:"toggle-chat",toggleFilmStrip:"toggle-film-strip",toggleShareScreen:"toggle-share-screen",toggleVideo:"toggle-video"},y={"avatar-changed":"avatarChanged","audio-availability-changed":"audioAvailabilityChanged","audio-mute-status-changed":"audioMuteStatusChanged","display-name-change":"displayNameChange","email-change":"emailChange","feedback-submitted":"feedbackSubmitted","incoming-message":"incomingMessage","outgoing-message":"outgoingMessage","participant-joined":"participantJoined","participant-left":"participantLeft","video-ready-to-close":"readyToClose","video-conference-joined":"videoConferenceJoined","video-conference-left":"videoConferenceLeft","video-availability-changed":"videoAvailabilityChanged","video-mute-status-changed":"videoMuteStatusChanged","screen-sharing-status-changed":"screenSharingStatusChanged"},_=0,b=function(e){function t(e){!function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t);for(var n=function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).call(this)),r=arguments.length,i=Array(r>1?r-1:0),s=1;s<r;s++)i[s-1]=arguments[s];var a=function(e){if(!e.length)return{};var t=e[0];switch(void 0===t?"undefined":d(t)){case"string":case void 0:var n=f(e,9);return{roomName:n[0],width:n[1],height:n[2],parentNode:n[3],configOverwrite:n[4],interfaceConfigOverwrite:n[5],noSSL:n[6],jwt:n[7],onload:n[8]};case"object":return e[0];default:throw new Error("Can't parse the arguments!")}}(i),u=a.roomName,c=void 0===u?"":u,h=a.width,v=void 0===h?"100%":h,g=a.height,m=void 0===g?"100%":g,y=a.parentNode,b=void 0===y?document.body:y,w=a.configOverwrite,L=void 0===w?{}:w,k=a.interfaceConfigOverwrite,x=void 0===k?{}:k,O=a.noSSL,j=void 0!==O&&O,E=a.jwt,S=void 0===E?void 0:E,C=a.onload,I=void 0===C?void 0:C,A=a.invitees;return n._parentNode=b,n._url=function(e){var t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:{};return Object(o.a)(p({},t,{url:(t.noSSL?"http":"https")+"://"+e+"/#jitsi_meet_external_api_id="+_}))}(e,{configOverwrite:L,interfaceConfigOverwrite:x,jwt:S,noSSL:j,roomName:c}),n._createIFrame(m,v,I),n._transport=new l.b({backend:new l.a({postisOptions:{scope:"jitsi_meet_external_api_"+_,window:n._frame.contentWindow}})}),Array.isArray(A)&&A.length>0&&n.invite(A),n._isLargeVideoVisible=!0,n._numberOfParticipants=0,n._participants={},n._myUserID=void 0,n._onStageParticipant=void 0,n._setupListeners(),_++,n}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,a.a),h(t,[{key:"_createIFrame",value:function(e,t,n){var r="jitsiConferenceFrame"+_;this._frame=document.createElement("iframe"),this._frame.allow="camera; microphone",this._frame.src=this._url,this._frame.name=r,this._frame.id=r,this._setSize(e,t),this._frame.setAttribute("allowFullScreen","true"),this._frame.style.border=0,n&&(this._frame.onload=n),this._frame=this._parentNode.appendChild(this._frame)}},{key:"_getAlwaysOnTopResources",value:function(){var e=this._frame.contentWindow,t="",n=e.document.querySelector("base");if(n&&n.href)t=n.href;else{var r=e.location,i=r.protocol,s=r.host;t=i+"//"+s}return g.map(function(e){return new URL(e,t).href})}},{key:"_getOnStageParticipant",value:function(){return this._onStageParticipant}},{key:"_getLargeVideo",value:function(){var e=this.getIFrame();if(this._isLargeVideoVisible&&e&&e.contentWindow&&e.contentWindow.document)return e.contentWindow.document.getElementById("largeVideo")}},{key:"_setSize",value:function(e,t){var n=i(e),r=i(t);void 0!==n&&(this._frame.style.height=n),void 0!==r&&(this._frame.style.width=r)}},{key:"_setupListeners",value:function(){var e=this;this._transport.on("event",function(t){var n=t.name,i=function(e,t){var n={};for(var r in e)t.indexOf(r)>=0||Object.prototype.hasOwnProperty.call(e,r)&&(n[r]=e[r]);return n}(t,["name"]),s=i.id;switch(n){case"video-conference-joined":e._myUserID=s,e._participants[s]={avatarURL:i.avatarURL};case"participant-joined":e._participants[s]=e._participants[s]||{},e._participants[s].displayName=i.displayName,e._participants[s].formattedDisplayName=i.formattedDisplayName,r(e,1);break;case"participant-left":r(e,-1),delete e._participants[s];break;case"display-name-change":var a=e._participants[s];a&&(a.displayName=i.displayname,a.formattedDisplayName=i.formattedDisplayName);break;case"email-change":var o=e._participants[s];o&&(o.email=i.email);break;case"avatar-changed":var l=e._participants[s];l&&(l.avatarURL=i.avatarURL);break;case"on-stage-participant-changed":e._onStageParticipant=s,e.emit("largeVideoChanged");break;case"large-video-visibility-changed":e._isLargeVideoVisible=i.isVisible,e.emit("largeVideoChanged");break;case"video-conference-left":r(e,-1),delete e._participants[e._myUserID]}var u=y[n];return!!u&&(e.emit(u,i),!0)})}},{key:"addEventListener",value:function(e,t){this.on(e,t)}},{key:"addEventListeners",value:function(e){for(var t in e)this.addEventListener(t,e[t])}},{key:"dispose",value:function(){this._transport.dispose(),this.removeAllListeners(),this._frame&&this._frame.parentNode.removeChild(this._frame)}},{key:"executeCommand",value:function(e){for(var t=arguments.length,n=Array(t>1?t-1:0),r=1;r<t;r++)n[r-1]=arguments[r];e in m?this._transport.sendEvent({data:n,name:m[e]}):v.error("Not supported command name.")}},{key:"executeCommands",value:function(e){for(var t in e)this.executeCommand(t,e[t])}},{key:"isAudioAvailable",value:function(){return this._transport.sendRequest({name:"is-audio-available"})}},{key:"invite",value:function(e){return Array.isArray(e)&&0!==e.length?this._transport.sendRequest({name:"invite",invitees:e}):Promise.reject(new TypeError("Invalid Argument"))}},{key:"isAudioMuted",value:function(){return this._transport.sendRequest({name:"is-audio-muted"})}},{key:"getAvatarURL",value:function(e){return(this._participants[e]||{}).avatarURL}},{key:"getDisplayName",value:function(e){return(this._participants[e]||{}).displayName}},{key:"getEmail",value:function(e){return(this._participants[e]||{}).email}},{key:"_getFormattedDisplayName",value:function(e){return(this._participants[e]||{}).formattedDisplayName}},{key:"getIFrame",value:function(){return this._frame}},{key:"getNumberOfParticipants",value:function(){return this._numberOfParticipants}},{key:"isVideoAvailable",value:function(){return this._transport.sendRequest({name:"is-video-available"})}},{key:"isVideoMuted",value:function(){return this._transport.sendRequest({name:"is-video-muted"})}},{key:"removeEventListener",value:function(e){this.removeAllListeners(e)}},{key:"removeEventListeners",value:function(e){var t=this;e.forEach(function(e){return t.removeEventListener(e)})}},{key:"_getElectronPopupsConfig",value:function(){return Promise.resolve(c.a)}}]),t}();t.default=b}.call(t,"modules/API/external/external_api.js")},function(e,t){function n(){this._events=this._events||{},this._maxListeners=this._maxListeners||void 0}function r(e){return"function"==typeof e}function i(e){return"object"==typeof e&&null!==e}function s(e){return void 0===e}e.exports=n,n.EventEmitter=n,n.prototype._events=void 0,n.prototype._maxListeners=void 0,n.defaultMaxListeners=10,n.prototype.setMaxListeners=function(e){if("number"!=typeof e||e<0||isNaN(e))throw TypeError("n must be a positive number");return this._maxListeners=e,this},n.prototype.emit=function(e){var t,n,a,o,l,u;if(this._events||(this._events={}),"error"===e&&(!this._events.error||i(this._events.error)&&!this._events.error.length)){if((t=arguments[1])instanceof Error)throw t;var c=new Error('Uncaught, unspecified "error" event. ('+t+")");throw c.context=t,c}if(s(n=this._events[e]))return!1;if(r(n))switch(arguments.length){case 1:n.call(this);break;case 2:n.call(this,arguments[1]);break;case 3:n.call(this,arguments[1],arguments[2]);break;default:o=Array.prototype.slice.call(arguments,1),n.apply(this,o)}else if(i(n))for(o=Array.prototype.slice.call(arguments,1),a=(u=n.slice()).length,l=0;l<a;l++)u[l].apply(this,o);return!0},n.prototype.addListener=function(e,t){var a;if(!r(t))throw TypeError("listener must be a function");return this._events||(this._events={}),this._events.newListener&&this.emit("newListener",e,r(t.listener)?t.listener:t),this._events[e]?i(this._events[e])?this._events[e].push(t):this._events[e]=[this._events[e],t]:this._events[e]=t,i(this._events[e])&&!this._events[e].warned&&(a=s(this._maxListeners)?n.defaultMaxListeners:this._maxListeners)&&a>0&&this._events[e].length>a&&(this._events[e].warned=!0,console.error("(node) warning: possible EventEmitter memory leak detected. %d listeners added. Use emitter.setMaxListeners() to increase limit.",this._events[e].length),"function"==typeof console.trace&&console.trace()),this},n.prototype.on=n.prototype.addListener,n.prototype.once=function(e,t){function n(){this.removeListener(e,n),i||(i=!0,t.apply(this,arguments))}if(!r(t))throw TypeError("listener must be a function");var i=!1;return n.listener=t,this.on(e,n),this},n.prototype.removeListener=function(e,t){var n,s,a,o;if(!r(t))throw TypeError("listener must be a function");if(!this._events||!this._events[e])return this;if(a=(n=this._events[e]).length,s=-1,n===t||r(n.listener)&&n.listener===t)delete this._events[e],this._events.removeListener&&this.emit("removeListener",e,t);else if(i(n)){for(o=a;o-- >0;)if(n[o]===t||n[o].listener&&n[o].listener===t){s=o;break}if(s<0)return this;1===n.length?(n.length=0,delete this._events[e]):n.splice(s,1),this._events.removeListener&&this.emit("removeListener",e,t)}return this},n.prototype.removeAllListeners=function(e){var t,n;if(!this._events)return this;if(!this._events.removeListener)return 0===arguments.length?this._events={}:this._events[e]&&delete this._events[e],this;if(0===arguments.length){for(t in this._events)"removeListener"!==t&&this.removeAllListeners(t);return this.removeAllListeners("removeListener"),this._events={},this}if(r(n=this._events[e]))this.removeListener(e,n);else if(n)for(;n.length;)this.removeListener(e,n[n.length-1]);return delete this._events[e],this},n.prototype.listeners=function(e){return this._events&&this._events[e]?r(this._events[e])?[this._events[e]]:this._events[e].slice():[]},n.prototype.listenerCount=function(e){if(this._events){var t=this._events[e];if(r(t))return 1;if(t)return t.length}return 0},n.listenerCount=function(e,t){return e.listenerCount(t)}},function(e,t,n){function r(e,t){this.logStorage=e,this.stringifyObjects=!(!t||!t.stringifyObjects)&&t.stringifyObjects,this.storeInterval=t&&t.storeInterval?t.storeInterval:3e4,this.maxEntryLength=t&&t.maxEntryLength?t.maxEntryLength:1e4,Object.keys(i.levels).forEach(function(e){this[i.levels[e]]=function(e){this._log.apply(this,arguments)}.bind(this,e)}.bind(this)),this.storeLogsIntervalID=null,this.queue=[],this.totalLen=0,this.outputCache=[]}var i=n(2);r.prototype.stringify=function(e){try{return JSON.stringify(e)}catch(e){return"[object with circular refs?]"}},r.prototype.formatLogMessage=function(e){for(var t="",n=1,r=arguments.length;n<r;n++){var s=arguments[n];!this.stringifyObjects&&e!==i.levels.ERROR||"object"!=typeof s||(s=this.stringify(s)),t+=s,n!=r-1&&(t+=" ")}return t.length?t:null},r.prototype._log=function(){var e=this.formatLogMessage.apply(this,arguments);if(e){var t=this.queue.length?this.queue[this.queue.length-1]:void 0;("object"==typeof t?t.text:t)==e?"object"==typeof t?t.count+=1:this.queue[this.queue.length-1]={text:e,count:2}:(this.queue.push(e),this.totalLen+=e.length)}this.totalLen>=this.maxEntryLength&&this._flush(!0,!0)},r.prototype.start=function(){this._reschedulePublishInterval()},r.prototype._reschedulePublishInterval=function(){this.storeLogsIntervalID&&(window.clearTimeout(this.storeLogsIntervalID),this.storeLogsIntervalID=null),this.storeLogsIntervalID=window.setTimeout(this._flush.bind(this,!1,!0),this.storeInterval)},r.prototype.flush=function(){this._flush(!1,!0)},r.prototype._flush=function(e,t){this.totalLen>0&&(this.logStorage.isReady()||e)&&(this.logStorage.isReady()?(this.outputCache.length&&(this.outputCache.forEach(function(e){this.logStorage.storeLogs(e)}.bind(this)),this.outputCache=[]),this.logStorage.storeLogs(this.queue)):this.outputCache.push(this.queue),this.queue=[],this.totalLen=0),t&&this._reschedulePublishInterval()},r.prototype.stop=function(){this._flush(!1,!1)},e.exports=r},function(e,t,n){"use strict";var r=n(8);n(9),n(1);var i=function(e){var t=arguments.length>1&&void 0!==arguments[1]&&arguments[1],n="search"===(arguments.length>2&&void 0!==arguments[2]?arguments[2]:"hash")?e.search:e.hash,i={};return n&&n.substr(1).split("&").forEach(function(e){var n=e.split("="),s=n[0];if(s){var a=void 0;try{a=n[1],t||(a=JSON.parse(decodeURIComponent(a).replace(/\\&/,"&")))}catch(e){return void Object(r.b)(e,"Failed to parse URL parameter value: "+String(a))}i[s]=a}}),i}(window.location).jitsi_meet_external_api_id,s=n(10),a=n.n(s),o=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},l=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),u={window:window.opener||window.parent},c=["avatar-url","display-name","email","toggle-audio","toggle-chat","toggle-film-strip","toggle-share-screen","toggle-video","video-hangup"],h=["display-name-change","incoming-message","outgoing-message","participant-joined","participant-left","video-conference-joined","video-conference-left","video-ready-to-close"],f="message",d=function(){function e(){var t=this,n=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{},r=n.enableLegacyFormat,i=n.postisOptions;!function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,e),this.postis=a()(o({},u,i)),this._enableLegacyFormat=r,this._enableLegacyFormat&&c.forEach(function(e){return t.postis.listen(e,function(n){return t._legacyMessageReceivedCallback(e,n)})}),this._receiveCallback=function(){},this.postis.listen(f,function(e){return t._receiveCallback(e)})}return l(e,[{key:"_legacyMessageReceivedCallback",value:function(e){var t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:{};this._receiveCallback({data:{name:e,data:t}})}},{key:"_sendLegacyMessage",value:function(e){var t=e.name,n=function(e,t){var n={};for(var r in e)t.indexOf(r)>=0||Object.prototype.hasOwnProperty.call(e,r)&&(n[r]=e[r]);return n}(e,["name"]);t&&-1!==h.indexOf(t)&&this.postis.send({method:t,params:n})}},{key:"dispose",value:function(){this.postis.destroy()}},{key:"send",value:function(e){this.postis.send({method:f,params:e}),this._enableLegacyFormat&&this._sendLegacyMessage(e.data||{})}},{key:"setReceiveCallback",value:function(e){this._receiveCallback=e}}]),e}(),p=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),v=function(){function e(){var t=(arguments.length>0&&void 0!==arguments[0]?arguments[0]:{}).backend;!function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,e),this._listeners=new Map,this._requestID=0,this._responseHandlers=new Map,this._unprocessedMessages=new Set,this.addListener=this.on,t&&this.setBackend(t)}return p(e,[{key:"_disposeBackend",value:function(){this._backend&&(this._backend.dispose(),this._backend=null)}},{key:"_onMessageReceived",value:function(e){var t=this;if("response"===e.type){var n=this._responseHandlers.get(e.id);n&&(n(e),this._responseHandlers.delete(e.id))}else"request"===e.type?this.emit("request",e.data,function(n,r){t._backend.send({type:"response",error:r,id:e.id,result:n})}):this.emit("event",e.data)}},{key:"dispose",value:function(){this._responseHandlers.clear(),this._unprocessedMessages.clear(),this.removeAllListeners(),this._disposeBackend()}},{key:"emit",value:function(e){for(var t=arguments.length,n=Array(t>1?t-1:0),r=1;r<t;r++)n[r-1]=arguments[r];var i=this._listeners.get(e),s=!1;return i&&i.size&&i.forEach(function(e){s=e.apply(void 0,n)||s}),s||this._unprocessedMessages.add(n),s}},{key:"on",value:function(e,t){var n=this,r=this._listeners.get(e);return r||(r=new Set,this._listeners.set(e,r)),r.add(t),this._unprocessedMessages.forEach(function(e){t.apply(void 0,function(e){if(Array.isArray(e)){for(var t=0,n=Array(e.length);t<e.length;t++)n[t]=e[t];return n}return Array.from(e)}(e))&&n._unprocessedMessages.delete(e)}),this}},{key:"removeAllListeners",value:function(e){return e?this._listeners.delete(e):this._listeners.clear(),this}},{key:"removeListener",value:function(e,t){var n=this._listeners.get(e);return n&&n.delete(t),this}},{key:"sendEvent",value:function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{};this._backend&&this._backend.send({type:"event",data:e})}},{key:"sendRequest",value:function(e){var t=this;if(!this._backend)return Promise.reject(new Error("No transport backend defined!"));this._requestID++;var n=this._requestID;return new Promise(function(r,i){t._responseHandlers.set(n,function(e){var t=e.error,n=e.result;void 0!==n?r(n):i(void 0!==t?t:new Error("Unexpected response format!"))}),t._backend.send({type:"request",data:e,id:n})})}},{key:"setBackend",value:function(e){this._disposeBackend(),this._backend=e,this._backend.setReceiveCallback(this._onMessageReceived.bind(this))}}]),e}();n.d(t,"a",function(){return d}),n.d(t,"b",function(){return v});var g={};"number"==typeof i&&(g.scope="jitsi_meet_external_api_"+i),Object(r.a)().setExternalTransportBackend=function(e){return(void 0).setBackend(e)}},function(e,t,n){"use strict";(function(e){t.a=function(){return window.JitsiMeetJS||(window.JitsiMeetJS={}),window.JitsiMeetJS.app||(window.JitsiMeetJS.app={}),window.JitsiMeetJS.app},t.b=function(e){var t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:"";r.error(t,e),window.onerror&&window.onerror(t,null,null,null,e)};var r=n(0).getLogger(e)}).call(t,"react/features/base/util/helpers.js")},function(e,t,n){"use strict";(function(e){n(0).getLogger(e)}).call(t,"react/features/base/util/httpUtils.js")},function(e,t){e.exports=function(e){var t,n=e.scope,r=e.window,i=e.windowForEventListening||window,s={},a=[],o={},l=!1,u=function(e){var t;try{t=JSON.parse(e.data)}catch(e){return}if(t.postis&&t.scope===n){var r=s[t.method];if(r)for(var i=0;i<r.length;i++)r[i].call(null,t.params);else o[t.method]=o[t.method]||[],o[t.method].push(t.params)}};i.addEventListener("message",u,!1);var c={listen:function(e,t){s[e]=s[e]||[],s[e].push(t);var n=o[e];if(n)for(var r=s[e],i=0;i<r.length;i++)for(var a=0;a<n.length;a++)r[i].call(null,n[a]);delete o[e]},send:function(e){var t=e.method;(l||"__ready__"===e.method)&&r&&"function"==typeof r.postMessage?r.postMessage(JSON.stringify({postis:!0,scope:n,method:t,params:e.params}),"*"):a.push(e)},ready:function(e){l?e():setTimeout(function(){c.ready(e)},50)},destroy:function(e){clearInterval(t),l=!1,i&&"function"==typeof i.removeEventListener&&i.removeEventListener("message",u),e&&e()}},h=+new Date+Math.random()+"";return t=setInterval(function(){c.send({method:"__ready__",params:h})},50),c.listen("__ready__",function(e){if(e===h){clearInterval(t),l=!0;for(var n=0;n<a.length;n++)c.send(a[n]);a=[]}else c.send({method:"__ready__",params:e})}),c}},function(e,t){e.exports={"google-auth":{matchPatterns:{url:"accounts.google.com"},target:"electron"}}}])});
//# sourceMappingURL=external_api.min.map