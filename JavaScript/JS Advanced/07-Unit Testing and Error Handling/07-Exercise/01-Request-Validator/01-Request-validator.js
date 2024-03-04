function solve(input = {}) {
    const validMethods = ["GET", "POST", "DELETE", "CONNECT"];
    const uriPattern = /^[\w.]+$/g;
    const validVersion = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const messagePattern = /^[^<>&'"\\]*$/;
    const errorMessage = "Invalid request header: Invalid";


    if (!input.method || !validMethods.includes(input.method)) {
        throw new Error(`${errorMessage} Method`);
    }

    if (!input.uri || !input.uri === "*" || !input.uri.match(uriPattern)) {
        throw new Error(`${errorMessage} URI`);
    }


    if (!input.version || !validVersion.includes(input.version)) {
        throw new Error(`${errorMessage} Version`);
    }

    if (!input.hasOwnProperty("message") || !input.message.match(messagePattern)) {
        throw new Error(`${errorMessage} Message`)
    }

    return input;
}

try {
    solve({
        method: 'GET',
        uri: 'svn.public.catalog',
        version: 'HTTP/1.1',
        message: ''
    }
    );
} catch (error) {
    console.log(error);

}

try {
    solve({
        method: 'OPTIONS',
        uri: 'git.master',
        version: 'HTTP/1.1',
        message: '-recursive'
    }
    )
} catch (error) {
    console.log(error);
}


console.log("____________");
try {
    solve({
        method: 'POST',
        uri: 'home.bash',
        message: 'rm -rf /*'
    }
    );
} catch (error) {
    console.log(error);
}
