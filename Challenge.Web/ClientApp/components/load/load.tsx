import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { TokenResult } from '../../model';
import { TokenEnum } from '../../common/enum';
import { CatalogContainer } from '../catalog/catalogContainer';
import { initializeIcons } from '@uifabric/icons';

interface LoadProps {
    token: string,
    tokenResult: TokenResult,
    validateToken: (token: string) => Promise<TokenResult>;
}

export class LoadComponent extends React.Component<RouteComponentProps<{}> & LoadProps> {

    public componentWillMount() {
        initializeIcons();
        this.props.validateToken(this.props.token);
    }

    public render() {
           return <CatalogContainer />;
        }
 }

