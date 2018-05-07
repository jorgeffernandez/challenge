import { ErrorToken } from '../../model/errorToken';
import * as React from 'react';

interface Props {
    error: string;
}

export class ErrorTokenInfo extends React.Component<Props> {
    constructor(props) {
        super(props);
    }

    public render() {
        return <div><h2>TOKEN ERROR: {this.props.error}</h2></div>;
    }
}
