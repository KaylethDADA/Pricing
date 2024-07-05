FROM node:alpine

# Указываем порты для экспоза
EXPOSE 19000 19001
EXPOSE 8081

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем все файлы из текущей директории в рабочую директорию образа
COPY . .

# Установка OpenJDK 8, curl и unzip
RUN apk update && apk add openjdk8 curl unzip
# Скачивание и установка Android SDK
RUN curl -sS https://dl.google.com/android/repository/sdk-tools-linux-4333796.zip -o android-sdk.zip && \
    mkdir -p /usr/local/android-sdk && \
    unzip -q android-sdk.zip -d /usr/local/android-sdk && \
    rm android-sdk.zip

# Установка переменных окружения для Android SDK
ENV ANDROID_HOME /usr/local/android-sdk
ENV PATH $PATH:$ANDROID_HOME/tools:$ANDROID_HOME/platform-tools

# Установка зависимостей проекта
RUN npm install

# Устанавливаем глобально Expo CLI
RUN npm install -g expo-cli

# Установка трансформера для SVG
RUN npm install --save-dev react-native-svg-transformer

# Установка metro-config и @react-native/metro-config
RUN npm install --save-dev metro-config @react-native/metro-config

# Установка @expo/ngrok глобально
RUN npm install -g @expo/ngrok

# Установка библиотек для веб-режима
RUN npx expo install react-native-web react-dom @expo/metro-runtime

# Команда для запуска приложения
CMD ["npm", "run", "web"]