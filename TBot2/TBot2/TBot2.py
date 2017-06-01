'''
Twitch Bot created by Nathan Glick.
'''


#---------Stuff To Import---------
import os
import re
import sys
import time
import socket
import urllib
import platform
import threading
import subprocess
from datetime import datetime
import config
from pip._vendor import requests
from threading import Thread
from random import randint

#---------Variables---------
s = socket.socket()
#cSock = socket.socket()
message = "null"
pointsExist = False
points = { 'a' : 100 }
#gamble = 0

#testing networking stuff
#c_connect()

#---------Open Point File---------
try:
    pointList = open("convertedCSV.txt", 'r+')
    #read_point_file(pointList)

    #reads in the points file
    nLine = pointList.readline()
    nLine = nLine.strip()
    while nLine != "":
        nLineSplit = nLine.split(' ')
        nLineName = nLineSplit[0]
        nLineCount = nLineSplit[1]
        points[nLineName] = nLineCount
        nLine = pointList.readline()
        nLine = nLine.strip()

    #if successful, prints out success
    print("Successfully opened points list")
    pointsExist = True
    pointList.close()
except:
    print("ERROR opening point list")
    pointsExist = False

#---------Get User URL-------
uURL = requests.get(config.USERURL)
userListRaw = uURL.text

#---------Methods---------
def c_connect():
    try:
        cSock.connect((config.IP, config.PORTc))
        #print("Connection to C# host successful")
    except:
        #print("ERROR: retyring C# connection")
        #time.sleep(1)
        c_connect()

def c_send_data():
    cSock = socket.socket()
    try:
        cSock.connect((config.IP, config.PORTc))
        cSock.send(bytes(config.TOSEND))
        #print("sent data to C# host")
        cSock.close()
        #print("Connection to C# host successful")
    except:
        print("ERROR in C# connection")
        #time.sleep(1)
        #c_connect()
    #c_connect()
    
def c_file_write(stuff):
    try:
        open("pyCconn", 'w').close()
        cmdFile = open("pyCconn", 'w')
        cmdFile.write(str(stuff))
        cmdFile.close()
    except:
        print("error updating cmdFile")

def irc_connect(): #connects bot to the twitch chat
    try:
        s.connect((config.HOST, config.PORT))
        print("connection successful")
    except:
        print("ERROR: retrying")
        time.sleep(1)
        irc_connect()
    s.send(bytes("CAP REQ :twitch.tv/membership\r\n", 'UTF-8'))
    s.send(bytes("CAP REQ :twitch.tv/commands\r\n", 'UTF-8'))
    s.send(bytes("PASS " + config.PASS + "\r\n", 'UTF-8'))
    s.send(bytes("NICK " + config.NICK + "\r\n", 'UTF-8'))
    s.send(bytes("JOIN " + config.CHAN + "\r\n", 'UTF-8'))


def send_pong(): #sends pong when requested by twitch
    s.send(bytes("PONG :tmi.twitch.tv\r\n", 'UTF-8'))
    print("Sent Pong")

def cmd_check(message): #checks chat message for a known command

        #checks for standard text responce command
        for stri in config.CMDS:
            if message.find(stri) != -1:
                s.send(bytes("PRIVMSG " + config.CHAN + " :" + config.CMDS[stri] + "\r\n", 'UTF-8'))
                print(config.CMDS[stri])

        #command for adding a user to the loyalty program
        if message.find("!addme") != -1:
            endOfName = message.find('!')
            user = message[1:endOfName]
            if (user in points.keys()) == False:
                points[user] = 0
                print("added " + user + " to list")
            else:
                s.send(bytes("PRIVMSG " + config.CHAN + " :" + user + " you're already on the list!" + "\r\n", 'UTF-8'))
                print(user + " is already on list")

        #checks if a user wants to redeem loyalty points
        if message.find("!redeem") != -1:
            endOfName = message.find('!')
            user = message[1:endOfName]
            if user in points.keys():
                uPoints = points[user]
                reAmtStrStart = message.find("!redeem")
                reAmtStrStart = reAmtStrStart + 8
                reAmtEnd = message.find("r", reAmtStrStart) - 1
                reAmtStr = message[reAmtStrStart:reAmtEnd]
                newPoints = int(uPoints) - int(reAmtStr)
                points[user] = str(newPoints)
                s.send(bytes("PRIVMSG " + config.CHAN + " :" + user + " just redeemed the " + reAmtStr + " reward! @" + config.STREAMER + "\r\n", 'UTF-8'))
                print(user + " redeemed " + reAmtStr + " reward")

        if message.find("!commands") != -1:
            cList = config.CMDS.keys()
            answer = "Here are my commands: "
            for stri in cList:
                answer += stri + ", "
            s.send(bytes("PRIVMSG " + config.CHAN + " :" + answer + "\r\n", 'UTF-8'))

        
        if config.GAMBLE:
            gamble_points(message)

        #moderation commands
        if message.find("!ban") != -1:
            if find_username(message) in config.MODS:
                userStart = message.find("!ban") + 5
                userEnd = message.find("r", userStart) - 1
                user = message[userStart:userEnd]
                s.send(bytes("PRIVMSG " + config.CHAN + " :" + ".ban " + user + "\r\n", 'UTF-8'))
                print("Banned " + user + " from the room")
        if message.find("!timeout") != -1:
            if find_username(message) in config.MODS:
                userStart = message.find("!timeout") + 9
                userEnd = message.find("r", userStart) - 1
                user = message[userStart:userEnd]
                s.send(bytes("PRIVMSG " + config.CHAN + " :" + ".timeout " + user + " 600" + "\r\n", 'UTF-8'))
                print("Timed out " + user + " from the room for 10 minutes")
        if message.find("!purge") != -1:
            if find_username(message) in config.MODS:
                userStart = message.find("!purge") + 7
                userEnd = message.find("r", userStart) - 1
                user = message[userStart:userEnd]
                s.send(bytes("PRIVMSG " + config.CHAN + " :" + ".timeout " + user + " 1" + "\r\n", 'UTF-8'))
                print("Purged " + user)
        if message.find("!unban") != -1:
            if find_username(message) in config.MODS:
                userStart = message.find("!unban") + 7
                userEnd = message.find("r", userStart) - 1
                user = message[userStart:userEnd]
                s.send(bytes("PRIVMSG " + config.CHAN + " :" + ".unban " + user + "\r\n", 'UTF-8'))
                print("Unbanned " + user + " from the room")
        if message.find("!startgamble") != -1:
            if find_username(message) in config.MODS:
                s.send(bytes("PRIVMSG " + config.CHAN + " :" + "Gambling is now open!" + "\r\n", 'UTF-8'))
                config.GAMBLE = True
                print("open")
        if message.find("!endgamble") != -1:
            if find_username(message) in config.MODS:
                s.send(bytes("PRIVMSG " + config.CHAN + " :" + "Gambling is now over!" + "\r\n", 'UTF-8'))
                config.GAMBLE = False

        #Streamer commands
        if message.find("!addmod") != -1: #not permanent, close bot & manually edit config file with mod changes
            if find_username(message) == config.STREAMER:
                userStart = message.find("!addmod") + 8
                user = message[userStart:]
                config.MODS.append(user)
                result = "Added " + user + " to my mod list"
                s.send(bytes("PRIVMSG " + config.CHAN + " :" + result + "\r\n", 'UTF-8'))
                print("Added " + user + " to mod list")
        if message.find("!remmod") != -1: #not permanent, close bot & manually edit config file with mod changes
            if find_username(message) == config.STREAMER:
                userStart = message.find("!remmod") + 8
                user = message[userStart:]
                config.MODS.append(user)
                result = "Removed " + user + " to my mod list"
                s.send(bytes("PRIVMSG " + config.CHAN + " :" + result + "\r\n", 'UTF-8'))
                print("Removed " + user + " from mod list")
        if message.find("!leave") != -1:
            if find_username(message) == config.STREAMER:
                s.close()

#find username
def find_username(message):
    endOfName = message.find('!')
    user = message[1:endOfName]
    return user

#adds user to loyalty list
def loyalty_auto_add(message):
    endOfName = message.find('!')
    user = message[1:endOfName]
    if (user in points.keys()) == False and user.count(' ') == 0:
        points[user] = '0'
        print("added " + user + " to list")

def get_user_list(): #doesn't work
    s.send(bytes("NAMES " + config.CHAN + " :" + "\r\n", 'UTF-8'))

#doesn't work for some reason
def read_point_file(pointList):
    nLine = pointList.readline()
    nLine = nLine.strip()
    while nLine != "":
        nLineSplit = nLine.split(' ')
        nLineName = nLineSplit[0]
        nLineCount = nLineSplit[1]
        points[nLineName] = nLineCount
        nLine = pointList.readline()
        nLine = nLine.strip()

def add_points(): #adds loyalty points to a user
    print("Adding points!")
    for stri in points.keys():
        if userListRaw.find(stri) != -1:
            newP = 0
            newP = int(points[stri]) + config.PANT
            points[stri] = str(newP)

def point_sys(): #method for controlling the loyalty program
    while True:
        time.sleep(config.WAIT)
        uURL = requests.get(config.USERURL)
        userListRaw = uURL.text
        add_points()

def update_point_file(): #method for updating the loyalty point database
    while True:
        time.sleep(35)
        try:
            print("UPDATING POINT FILE, DO NOT DELETE, MODIFY, OR OPEN FILE. DO NOT CLOSE THE BOT")
            open("convertedCSV.txt", 'w').close()
            pointList2 = open("convertedCSV.txt", 'w')
            for stri in points:
                pointList2.write(stri + " " + points[stri])
                pointList2.write("\n")
            pointList2.close()
            print("UPDATING COMPLETE!")
        except:
            print("error updating file")

def gamble_points(message): #method that handles gambling
    #if gamble == True:
        if message.find("!gamble") != -1:
            user = find_username(message)
            reAmtStrStart = message.find("!gamble")
            reAmtStrStart = reAmtStrStart + 8
            reAmtEnd = message.find("r", reAmtStrStart) - 1
            reAmtStr = message[reAmtStrStart:reAmtEnd]
            gAmtInt = int(reAmtStr)
            if user in points.keys():
                if int(points[user]) - gAmtInt >= 0:
                    points[user] = str(int(points[user]) - gAmtInt)
                    rNum = randint(1,100)
                    if rNum >= 60:
                        gAmtInt = gAmtInt * 2
                        points[user] = str(int(points[user]) + gAmtInt)
                        result = "Rolled " + str(rNum) + ". " + user + " won " + str(gAmtInt) + " and now has " + points[user]
                        s.send(bytes("PRIVMSG " + config.CHAN + " :" + result + "\r\n", 'UTF-8'))
                    else:
                        result = "Rolled " + str(rNum) + ". " + user + " lost " + str(gAmtInt) + " and now has " + points[user]
                        s.send(bytes("PRIVMSG " + config.CHAN + " :" + result + "\r\n", 'UTF-8'))

#---------Main---------
irc_connect() #connect to twitch chat

#create threads for loyalty system
pThr = threading.Thread(target = point_sys)
uThr = threading.Thread(target = update_point_file)
uThr.daemon = True
pThr.daemon = True

#start threads
pThr.start()
uThr.start()
print("Threads Started!")

s.send(bytes("PRIVMSG " + config.CHAN + " :" + "Hello! I am RazekiiBot, an automated Twitch chat bot created by Razekii!" + "\r\n", 'UTF-8'))
#c_connect()

'''
#testing thread stuff
cThr = threading.Thread(target = c_send_data)
cThr.daemon = True
cThr.start()
'''

#main loop
while True:
    message = s.recv(1024).decode('UTF-8') #check for new chat message
    print(message) #print new message
    #c_send_data(message)

    if message == "PING :tmi.twitch.tv\r\n": #checks for a ping request from twitch
        send_pong()
    else:
        try:
            cmd_check(message) #check for commands
            loyalty_auto_add(message) #automatically add new users to the loyalty list if they talk in chat
            #uURL = requests.get(config.USERURL)
        except:
            print("Error with chat commands or auto-adding user to loyalty list")
            s.send(bytes("PRIVMSG " + config.CHAN + " :" + "Something weird happened, @" + config.STREAMER + " check the bot for debug info" + "\r\n", 'UTF-8'))
        time.sleep(1/config.RATE)
    '''
    config.TOSEND = message
    cThr = threading.Thread(target = c_send_data)
    cThr.daemon = True
    cThr.start()
    #c_send_data()
    '''
        