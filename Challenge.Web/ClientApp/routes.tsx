import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { LoadContainter } from './components/load/loadContainer';

export const routes = <Layout>
    <LoadContainter />
</Layout>;
