function num(a) {
    if (a != null && a.toString() != "") {
        let r = /^-?(0|[1-9]+\d*|[1-9]+\d*\.\d+|0\.\d+)$/;
        if (r.test(a.toString())) {
            return true;
        }
    }
    return false;
}

export function plus(a, b) {
    if (!num(a) || !num(b)) {
        return null;
    }
    let c, d, m;
    try {
        c = a.toString().split(".")[1].length;
    } catch (e) {
        c = 0;
    }
    try {
        d = b.toString().split(".")[1].length;
    } catch (e) {
        d = 0;
    }
    m = Math.pow(10, Math.max(c, d));
    return (a * m + b * m) / m;
}

export function minus(a, b) {
    if (!num(a) || !num(b)) {
        return null;
    }
    let c, d, m, n;
    try {
        c = a.toString().split(".")[1].length;
    } catch (e) {
        c = 0;
    }
    try {
        d = b.toString().split(".")[1].length;
    } catch (e) {
        d = 0;
    }
    m = Math.pow(10, Math.max(c, d));
    return (a * m - b * m) / m;
}

export function multiply(a, b) {
    let m = 0,
        c = a.toString(),
        d = b.toString();
    try {
        m += c.split(".")[1].length
    } catch (e) {}
    try {
        m += d.split(".")[1].length
    } catch (e) {}
    return Number(c.replace(".", "")) * Number(d.replace(".", "")) / Math.pow(10, m)
}

export function division(a, b) {
    if (!num(a) || !num(b)) {
        return null;
    }
    let c, d, f, g;
    try {
        c = a.toString().split(".")[1].length;
    } catch (e) {
        c = 0;
    }

    try {
        d = b.toString().split(".")[1].length;
    } catch (e) {
        d = 0;
    }

    f = Number(a.toString().replace(".", ""));
    g = Number(b.toString().replace(".", ""));
    return (f / g) * Math.pow(10, d - c);

}