FROM node:alpine

# Update
RUN apk add --update nodejs

# Create app directory
WORKDIR /usr/src/app

# Install app dependencies
COPY package.json .
COPY bower.json .bowerrc*

RUN npm install

# Bundle app source
COPY . .

EXPOSE 8080

CMD [ "npm", "start" ]