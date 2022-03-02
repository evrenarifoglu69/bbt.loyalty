FROM node:lts-alpine
ENV NODE_ENV=production
WORKDIR /usr/src/app
COPY ["src/Ui/package.json", "src/Ui/package-lock.json*", "src/Ui/npm-shrinkwrap.json*", "./"]
RUN npm install --production --silent && mv node_modules ../
# trigger test
COPY . .
EXPOSE 3000
RUN chown -R node /usr/src/app
USER node
CMD ["npm", "start"]
